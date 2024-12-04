using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImagesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("this is this the images get method on the controller ");
        }
    }
}
