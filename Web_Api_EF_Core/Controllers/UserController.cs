using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api_EF_Core.Data;
using Web_Api_EF_Core.Models;

namespace Web_Api_EF_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            //return Ok(users);
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            //User? user = users.Find(u => u.Id == id);
            User? user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return BadRequest("User not found!");
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<List<User>>> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User updateUser)
        {
            User? dbUser = await _context.Users.FindAsync(updateUser.Id);
            if (dbUser == null)
            {
                return BadRequest("User not found!");
            }

            dbUser.FirstName = updateUser.FirstName;
            dbUser.LastName = updateUser.LastName;
            dbUser.Age = updateUser.Age;
            dbUser.Email = updateUser.Email;
            dbUser.Phone = updateUser.Phone;

            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<User>>> DeleteUser(int id)
        {
            //User? user = users.Find(u => u.Id == id);
            User? dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
            {
                return BadRequest("User not found!");
            }

            _context.Users.Remove(dbUser);
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}
