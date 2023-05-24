using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAUIapi.Context;
using MAUIapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MAUIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ImageController(ApplicationDbContext context)
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

            // Validate the user data
            if (string.IsNullOrEmpty(user.Name) ||
                string.IsNullOrEmpty(user.Phone) ||
                string.IsNullOrEmpty(user.Address))
            {
                return BadRequest("Name, phone number, and address are required fields.");
            }

            try
            {
                // Save the user to the database

                _context.Users.Add(user);
                _context.SaveChanges();

                // Return a success response
                return Ok("User information saved to the database.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions and return an error response
                return StatusCode(500, $"Failed to save user information: {ex.Message}");
            }
        }
    }
}
