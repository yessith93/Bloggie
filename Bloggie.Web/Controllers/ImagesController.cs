using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : Controller
    {
        private readonly IImageRepository _imageRepository;
        public ImagesController(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("this is this the images get method on the controller ");
        }

        [HttpPost]
        public async Task<IActionResult> UploadAsync(IFormFile file)
        {
            var imageUrl = await _imageRepository.UploadAsync(file);
            if (string.IsNullOrEmpty(imageUrl))
            {
                return BadRequest("Error al cargar la imagen");
            }
            return Json(new {link = imageUrl });
        }
    }
}
