using Microsoft.AspNetCore.Mvc;
using ASP_TEST_3ITB.Models;
using ASP_TEST_3ITB.Services;

namespace ASP_TEST_3ITB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(
            IUserService userService
            )
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public User GetUser()
        {
            return new User();
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser(User user)
        {
            if (user == null)
                return BadRequest();

            await _userService.AddUserAsync(user);

            return Ok(); 
        }

        [HttpPut]
        [Route("")]
        public void UpdateUser()
        {
        }

        [HttpDelete]
        [Route("")]
        public void DeleteUser()
        {

        }
    }
}
