using ASP_TEST_3ITB.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_TEST_3ITB
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(
            DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
    }
}
