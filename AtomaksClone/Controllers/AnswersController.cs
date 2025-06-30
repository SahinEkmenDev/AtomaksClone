using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AtomaksClone.Data;
using AtomaksClone.Models;
using AtomaksClone.DTOs;
using AtomaksClone.Services;

namespace AtomaksClone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnswersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/answers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswers()
        {
            var answers = await _context.Answers
                .Include(a => a.Question)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AnswerDto>>(answers));
        }

        // GET: api/answers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerDto>> GetAnswer(int id)
        {
            var answer = await _context.Answers
                .Include(a => a.Question)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (answer == null)
                return NotFound("Cevap bulunamadı.");

            return Ok(_mapper.Map<AnswerDto>(answer));
        }

        // POST: api/answers
        [HttpPost]
        public async Task<ActionResult<AnswerDto>> CreateAnswer(
     [FromForm] CreateAnswerDto createAnswerDto,
     IFormFile icon,
     [FromServices] PhotoService photoService)
        {
            // Sorunun var olup olmadığını kontrol et
            var question = await _context.Questions.FindAsync(createAnswerDto.QuestionId);
            if (question == null)
                return BadRequest("Belirtilen soru bulunamadı.");

            // Ürünlerin var olup olmadığını kontrol et
            if (createAnswerDto.ProductImpacts.Any())
            {
                var productIds = createAnswerDto.ProductImpacts.Select(pi => pi.ProductId).ToList();
                var existingProducts = await _context.Products
                    .Where(p => productIds.Contains(p.Id))
                    .Select(p => p.Id)
                    .ToListAsync();

                var missingProducts = productIds.Except(existingProducts).ToList();
                if (missingProducts.Any())
                    return BadRequest($"Aşağıdaki ürün ID'leri bulunamadı: {string.Join(", ", missingProducts)}");
            }

            var answer = _mapper.Map<Answer>(createAnswerDto);
            answer.CreatedAt = DateTime.UtcNow;
            answer.IsActive = true;

            // Icon upload
            if (icon != null)
            {
                var iconUrl = await photoService.UploadPhotoAsync(icon);
                answer.IconUrl = iconUrl;
            }

            _context.Answers.Add(answer);
            await _context.SaveChangesAsync();

            // Cevap etkilerini ekle
            if (createAnswerDto.ProductImpacts.Any())
            {
                var answerImpacts = createAnswerDto.ProductImpacts.Select(pi => new AnswerImpact
                {
                    AnswerId = answer.Id,
                    ProductId = pi.ProductId,
                    Point = pi.Point,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true
                }).ToList();

                _context.AnswerImpacts.AddRange(answerImpacts);
                await _context.SaveChangesAsync();
            }

            var answerDto = _mapper.Map<AnswerDto>(answer);
            return CreatedAtAction(nameof(GetAnswer), new { id = answer.Id }, answerDto);
        }


        // PUT: api/answers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AnswerDto>> UpdateAnswer(
      int id,
      [FromForm] UpdateAnswerDto updateAnswerDto,
      IFormFile icon,
      [FromServices] PhotoService photoService)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
                return NotFound("Cevap bulunamadı.");

            answer.Text = updateAnswerDto.Text;
            answer.UpdatedAt = DateTime.UtcNow;

            // Icon upload
            if (icon != null)
            {
                var iconUrl = await photoService.UploadPhotoAsync(icon);
                answer.IconUrl = iconUrl;
            }

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<AnswerDto>(answer));
        }


        // DELETE: api/answers/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _context.Answers.FindAsync(id);
            if (answer == null)
                return NotFound("Cevap bulunamadı.");

            _context.Answers.Remove(answer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/answers/by-question/{questionId}
        [HttpGet("by-question/{questionId}")]
        public async Task<ActionResult<IEnumerable<AnswerDto>>> GetAnswersByQuestion(int questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if (question == null)
                return NotFound("Soru bulunamadı.");

            var answers = await _context.Answers
                .Where(a => a.QuestionId == questionId)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AnswerDto>>(answers));
        }
    }
}
