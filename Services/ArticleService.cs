
using ASP_TEST_3ITB.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASP_TEST_3ITB.Services
{
    public class ArticleService : IArticleService
    {
        private readonly AppDbContext _context;

        public ArticleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Article> GetArticleAsync(int id)
        {
            return await _context.Articles
                .Include(a => a.Author)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddArticleAsync(Article article)
        {
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
        }
    }
}