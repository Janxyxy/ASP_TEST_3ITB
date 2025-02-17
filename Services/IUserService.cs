using ASP_TEST_3ITB.Models;

namespace ASP_TEST_3ITB.Services
{
    public interface IUserService
    {
        Task<User> GetUserAsync(int id);

        Task<List<User>> GetUsersByPatternAsync(string pattern);

        Task AddUserAsync(User user);
    }
}
