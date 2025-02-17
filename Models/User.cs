namespace ASP_TEST_3ITB.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
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