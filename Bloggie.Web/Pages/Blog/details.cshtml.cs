using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Bloggie.Web.Repositories.Likes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bloggie.Web.Pages.Blog
{
    public class detailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        public int Likes { get; set; }

        public BlogPost BlogPost { get; set; }
        public detailsModel(IBlogPostRepository blogPostRepository, IBlogPostLikeRepository blogPostLikeRepository)
        {
            _blogPostRepository = blogPostRepository;
            _blogPostLikeRepository = blogPostLikeRepository;
        }
        public async Task<IActionResult> OnGet(string UrlHandle)
        {
            BlogPost = await _blogPostRepository.GetBlogPostByUrlAsync(UrlHandle);
            if (BlogPost != null && BlogPost.Id != null)
            {
                Likes = await _blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
            }
            else {
                Likes = 0;            
            }
                return Page();
        }
    }
}
