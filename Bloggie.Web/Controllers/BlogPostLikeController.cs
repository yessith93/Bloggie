using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        [Route("Add")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
