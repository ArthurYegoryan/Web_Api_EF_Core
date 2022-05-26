using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api_EF_Core.Models;

namespace Web_Api_EF_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> users = new List<User>
        {
            new User {
                Id = 1,
                FirstName = "Aram",
                LastName = "Aramyan",
                Age = 25,
                Email = "aa@gmail.com",
                Phone = "099-99-99-99"},
            new User {
                Id = 2,
                FirstName = "Sargis",
                LastName = "Sargsyan",
                Age = 30, Email = "ss@gmail.com",
                Phone = "077-77-77-77"},
            new User {
                Id = 3,
                FirstName = "Grigor",
                LastName = "Grigoryan",
                Age = 35,
                Email = "gg@gmail.com",
                Phone = "060-66-66-66"}
        };

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            users.Add(user);
            return Ok(users);
        }
    }
}
