using Microsoft.AspNetCore.Mvc;
using ASP_TEST_3ITB.Models;

namespace ASP_TEST_3ITB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public User GetUser()
        {
            return new User();
        }

        [HttpPost]
        [Route("")]
        public void AddUser()
        {

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
