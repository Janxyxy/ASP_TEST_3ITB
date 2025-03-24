using ASP_TEST_3ITB.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ASP_TEST_3ITB.Services
{
    public interface IArticleService
    {
        Task<Article> GetArticleAsync(int id);
        Task AddArticleAsync(Article article);
    }
}
