using ASP_TEST_3ITB.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_TEST_3ITB.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        /* Dependency injection */
        public UserService(AppDbContext db)
        {
            _context = db;
        }

        public async Task AddUserAsync(User user)
        {
            Console.WriteLine("User added");

            var res = _context.Users.Add(user);
            int affectedRows = await _context.SaveChangesAsync();
            
            if(affectedRows > 0)
            {
                return;
            } else
            {
                throw new Exception("Cannot add user");
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            Console.WriteLine($"Searching for User { id } ");
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                throw new Exception($"User with id {id} not found");
            }
            return user;
        }

        public async Task<List<User>> GetUsersByPatternAsync(string pattern)
        {
            Console.WriteLine($"Searching for Users with pattern {pattern} ");
            return await _context.Users
                .Where(u => u.Name.Contains(pattern) || u.Email.Contains(pattern))
                .ToListAsync();
        }
    }
}
