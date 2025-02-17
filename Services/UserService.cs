using ASP_TEST_3ITB.Models;

namespace ASP_TEST_3ITB.Services
{
    public class UserService : IUserService
    {
        /* Dependency injection */
        public UserService()
        {

        }

        public async Task AddUserAsync(User user)
        {
            Console.WriteLine("User added");
        }

        public async Task<User> GetUserAsync(int id)
        {
            Console.WriteLine($"Searching for User { id } ");
            return new User(); // TODO Implement
        }

        public async Task<List<User>> GetUsersByPatternAsync(string pattern)
        {
            Console.WriteLine($"Searching for Users with pattern {pattern} ");
            return new List<User>(); // TODO Implement
        }
    }
}
