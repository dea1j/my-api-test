using MAUIapi.Context;
using MAUIapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAUIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data.");
            }

            if (string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Phone) ||
                string.IsNullOrEmpty(user.Address))
            {
                return BadRequest("Name, phone number, and address are required fields.");
            }

            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User information saved to the database.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Failed to save user information: {ex.Message}");
            }
        }
    }
}
