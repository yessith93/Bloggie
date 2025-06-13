using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Bloggie.Web.Repositories.Likes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bloggie.Web.Pages.Blog
{
    public class detailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IBlogPostLikeRepository _blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public int Likes { get; set; }
        public bool Liked { get; set; }

        public BlogPost BlogPost { get; set; }
        public detailsModel(
            IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager
            )
        {
            _blogPostRepository = blogPostRepository;
            _blogPostLikeRepository = blogPostLikeRepository;
            this._signInManager = signInManager;
            this._userManager = userManager;
        }
        public async Task<IActionResult> OnGet(string UrlHandle)
        {
            BlogPost = await _blogPostRepository.GetBlogPostByUrlAsync(UrlHandle);
            if (BlogPost != null && BlogPost.Id != null)
            {
                Likes = await _blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);
                
                if (_signInManager.IsSignedIn(User))
                {
                    var likes = await _blogPostLikeRepository.GetLikesForBlog(BlogPost.Id);

                    var userId = _userManager.GetUserId(User);

                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));
                }
            }
            else
            {
                Likes = 0;
            }
                return Page();
        }
    }
}
