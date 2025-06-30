using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using AtomaksClone.Data;
using AtomaksClone.Models;
using AtomaksClone.DTOs;

namespace AtomaksClone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnswerImpactsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AnswerImpactsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/answerimpacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnswerImpactDto>>> GetAnswerImpacts()
        {
            var answerImpacts = await _context.AnswerImpacts
                .Include(ai => ai.Answer)
                .Include(ai => ai.Product)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AnswerImpactDto>>(answerImpacts));
        }

        // GET: api/answerimpacts/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AnswerImpactDto>> GetAnswerImpact(int id)
        {
            var answerImpact = await _context.AnswerImpacts
                .Include(ai => ai.Answer)
                .Include(ai => ai.Product)
                .FirstOrDefaultAsync(ai => ai.Id == id);

            if (answerImpact == null)
                return NotFound("Cevap etkisi bulunamadı.");

            return Ok(_mapper.Map<AnswerImpactDto>(answerImpact));
        }

        // POST: api/answerimpacts
        [HttpPost]
        public async Task<ActionResult<AnswerImpactDto>> CreateAnswerImpact(CreateAnswerImpactDto createAnswerImpactDto)
        {
            var answer = await _context.Answers.FindAsync(createAnswerImpactDto.AnswerId);
            if (answer == null)
                return BadRequest("Belirtilen cevap bulunamadı.");

            var product = await _context.Products.FindAsync(createAnswerImpactDto.ProductId);
            if (product == null)
                return BadRequest("Belirtilen ürün bulunamadı.");

            var answerImpact = _mapper.Map<AnswerImpact>(createAnswerImpactDto);
            answerImpact.CreatedAt = DateTime.UtcNow;
            answerImpact.IsActive = true;

            _context.AnswerImpacts.Add(answerImpact);
            await _context.SaveChangesAsync();

            var answerImpactDto = _mapper.Map<AnswerImpactDto>(answerImpact);
            return CreatedAtAction(nameof(GetAnswerImpact), new { id = answerImpact.Id }, answerImpactDto);
        }

        // PUT: api/answerimpacts/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AnswerImpactDto>> UpdateAnswerImpact(int id, UpdateAnswerImpactDto updateAnswerImpactDto)
        {
            var answerImpact = await _context.AnswerImpacts.FindAsync(id);
            if (answerImpact == null)
                return NotFound("Cevap etkisi bulunamadı.");

            answerImpact.Point = updateAnswerImpactDto.Point;
            answerImpact.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<AnswerImpactDto>(answerImpact));
        }

        // DELETE: api/answerimpacts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnswerImpact(int id)
        {
            var answerImpact = await _context.AnswerImpacts.FindAsync(id);
            if (answerImpact == null)
                return NotFound("Cevap etkisi bulunamadı.");

            _context.AnswerImpacts.Remove(answerImpact);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // GET: api/answerimpacts/by-answer/{answerId}
        [HttpGet("by-answer/{answerId}")]
        public async Task<ActionResult<IEnumerable<AnswerImpactDto>>> GetImpactsByAnswer(int answerId)
        {
            var answer = await _context.Answers.FindAsync(answerId);
            if (answer == null)
                return NotFound("Cevap bulunamadı.");

            var impacts = await _context.AnswerImpacts
                .Include(ai => ai.Product)
                .Where(ai => ai.AnswerId == answerId)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AnswerImpactDto>>(impacts));
        }

        // GET: api/answerimpacts/by-product/{productId}
        [HttpGet("by-product/{productId}")]
        public async Task<ActionResult<IEnumerable<AnswerImpactDto>>> GetImpactsByProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null)
                return NotFound("Ürün bulunamadı.");

            var impacts = await _context.AnswerImpacts
                .Include(ai => ai.Answer)
                .Where(ai => ai.ProductId == productId)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<AnswerImpactDto>>(impacts));
        }
    }
}
