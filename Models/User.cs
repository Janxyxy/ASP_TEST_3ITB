using System.ComponentModel.DataAnnotations;

namespace ASP_TEST_3ITB.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(100), Required]
        public string Name { get; set; }

        [MaxLength(320), EmailAddress, Required]
        public string Email { get; set; }

        [MaxLength(320), Required]
        public string Password { get; set; }

        public bool IsMale { get; set; }

        public bool Deleted { get; set; }

        public int Role { get; set; }

        public User()
        {
            Name ??= "";
            Email ??= "";
            Password ??= "";
        }
    }
}