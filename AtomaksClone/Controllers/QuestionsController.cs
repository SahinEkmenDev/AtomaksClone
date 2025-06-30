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
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuestionsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/questions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            var questions = await _context.Questions
                .Include(q => q.Answers)
                .ToListAsync();

            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(questions));
        }

        // GET: api/questions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<QuestionDto>> GetQuestion(int id)
        {
            var question = await _context.Questions
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return NotFound("Soru bulunamadı.");

            return Ok(_mapper.Map<QuestionDto>(question));
        }

        // POST: api/questions
        [HttpPost]
        public async Task<ActionResult<QuestionDto>> CreateQuestion(CreateQuestionDto createQuestionDto)
        {
            var question = _mapper.Map<Question>(createQuestionDto);
            question.CreatedAt = DateTime.UtcNow;
            question.IsActive = true;

            _context.Questions.Add(question);
            await _context.SaveChangesAsync();

            var questionDto = _mapper.Map<QuestionDto>(question);
            return CreatedAtAction(nameof(GetQuestion), new { id = question.Id }, questionDto);
        }

        // PUT: api/questions/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<QuestionDto>> UpdateQuestion(int id, UpdateQuestionDto updateQuestionDto)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                return NotFound("Soru bulunamadı.");

            question.Text = updateQuestionDto.Text;
            question.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<QuestionDto>(question));
        }

        // DELETE: api/questions/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            if (question == null)
                return NotFound("Soru bulunamadı.");

            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
