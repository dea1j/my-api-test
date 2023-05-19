using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAUIapi.Context;
using MAUIapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> SaveImage([FromBody] string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return BadRequest();

            var image = new Image
            {
                Path = imagePath,
                Timestamp = DateTime.Now
            };

            _context.Images.Add(image);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
