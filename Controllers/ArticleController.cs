using Microsoft.AspNetCore.Mvc;
using ASP_TEST_3ITB.Models;
using ASP_TEST_3ITB.Services;
using System.Threading.Tasks;

namespace ASP_TEST_3ITB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly IUserService _userService;

        public ArticleController(IArticleService articleService, IUserService userService)
        {
            _articleService = articleService;
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(int id)
        {
            var article = await _articleService.GetArticleAsync(id);
            if (article == null)
            {
                return NotFound($"Article with ID {id} not found.");
            }
            return Ok(article.ToDTO());
        }

        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody] ArticleDTO articleDTO, [FromQuery] int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            var article = new Article
            {
                Title = articleDTO.Title,
                Content = articleDTO.Content,
                Date = articleDTO.Date,
                Author = user
            };

            await _articleService.AddArticleAsync(article);
            return CreatedAtAction(nameof(GetArticle), new { id = article.Id }, article.ToDTO());
        }
    }
}
