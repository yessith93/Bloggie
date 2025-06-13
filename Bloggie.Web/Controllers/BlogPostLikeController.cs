using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories.Likes;
using Microsoft.AspNetCore.Mvc;

namespace Bloggie.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        public IBlogPostLikeRepository _BlogPostLikeRepository { get; }
        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            _BlogPostLikeRepository = blogPostLikeRepository;
        }


        [Route("Add")]
        public async Task<IActionResult> Addlike([FromBody] AddBlogPostLikeRequest addBlogPostLikeRequest)
        {
            await _BlogPostLikeRepository.AddLikeForBlog(addBlogPostLikeRequest.BlogPostId, addBlogPostLikeRequest.UserId);
            return Ok(); 
        }
    }
}
