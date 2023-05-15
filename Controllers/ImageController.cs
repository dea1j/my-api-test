using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MAUIapi.Contracts;
using MAUIapi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAUIapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _imageRepository;

        public ImageController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        [HttpPost]
        public async Task<ActionResult> UploadImage([FromBody] byte[] imageData)
        {
            try
            {
                ImageEntity imageEntity = new ImageEntity
                {
                    ImageData = imageData,
                    Timestamp = DateTime.UtcNow
                };
                await _imageRepository.UploadImage(imageEntity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to upload image" + ex.Message);
            }
        }
    }
}
