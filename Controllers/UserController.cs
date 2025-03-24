using Microsoft.AspNetCore.Mvc;
using ASP_TEST_3ITB.Models;
using ASP_TEST_3ITB.Services;
using System.Threading.Tasks;

namespace ASP_TEST_3ITB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        [Route("search/{pattern}")]
        public async Task<IActionResult> GetUsersByPattern(string pattern)
        {
            var users = await _userService.GetUsersByPatternAsync(pattern);
            if (users == null || users.Count == 0)
                return NotFound();

            return Ok(users);
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
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (user == null || id != user.Id)
                return BadRequest();

            var existingUser = await _userService.GetUserAsync(id);
            if (existingUser == null)
                return NotFound();

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.IsMale = user.IsMale;
            existingUser.Deleted = user.Deleted;
            existingUser.Role = user.Role;

            await _userService.AddUserAsync(existingUser);

            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.GetUserAsync(id);
            if (user == null)
                return NotFound();

            user.Deleted = true;
            await _userService.AddUserAsync(user);

            return Ok();
        }
    }
}
