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
    public class QuizController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public QuizController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/quiz/questions
        [HttpGet("questions")]
        public async Task<ActionResult<IEnumerable<QuestionDto>>> GetQuestions()
        {
            var questions = await _context.Questions
                .Include(q => q.Answers)
                .ToListAsync();

            if (!questions.Any())
                return NotFound("Hiç quiz sorusu bulunamadı.");

            return Ok(_mapper.Map<IEnumerable<QuestionDto>>(questions));
        }

        // POST: api/quiz/submit
        [HttpPost("submit")]
        public async Task<ActionResult<ProductRecommendationDto>> SubmitQuiz([FromBody] QuizSubmitDto quizSubmitDto)
        {
            if (quizSubmitDto.AnswerIds == null || !quizSubmitDto.AnswerIds.Any())
                return BadRequest(new { message = "En az bir cevap seçilmelidir." });

            var productScores = await _context.AnswerImpacts
                .Where(ai => quizSubmitDto.AnswerIds.Contains(ai.AnswerId))
                .GroupBy(ai => ai.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalScore = g.Sum(ai => ai.Point)
                })
                .OrderByDescending(x => x.TotalScore)
                .ToListAsync();

            if (!productScores.Any())
                return NotFound(new { message = "Seçilen cevaplara uygun hiçbir ürün bulunamadı." });

            var topProduct = productScores.First();
            var recommendedProduct = await _context.Products
                .FirstOrDefaultAsync(p => p.Id == topProduct.ProductId);

            if (recommendedProduct == null)
                return NotFound(new { message = "Önerilen ürün bulunamadı." });

            var result = _mapper.Map<ProductRecommendationDto>(recommendedProduct);
            result.TotalScore = topProduct.TotalScore;

            return Ok(new
            {
                message = "Quiz sonucunuz başarıyla hesaplandı!",
                recommendedProduct = result,
                totalQuestionsAnswered = quizSubmitDto.AnswerIds.Count,
                allProductScores = productScores.Take(3).Select(ps => new
                {
                    ProductId = ps.ProductId,
                    Score = ps.TotalScore
                })
            });
        }

        // GET: api/quiz/stats
        [HttpGet("stats")]
        public async Task<ActionResult<object>> GetStats()
        {
            var questionCount = await _context.Questions.CountAsync();
            var answerCount = await _context.Answers.CountAsync();
            var productCount = await _context.Products.CountAsync();
            var impactCount = await _context.AnswerImpacts.CountAsync();

            return Ok(new
            {
                totalQuestions = questionCount,
                totalAnswers = answerCount,
                totalProducts = productCount,
                totalAnswerImpacts = impactCount,
                averageAnswersPerQuestion = questionCount > 0 ? (double)answerCount / questionCount : 0,
                averageImpactsPerAnswer = answerCount > 0 ? (double)impactCount / answerCount : 0
            });
        }
    }
}
