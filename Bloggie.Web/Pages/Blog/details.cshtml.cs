using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Bloggie.Web.Repositories.Comments;
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
        private readonly IBlogPostCommentRepository _BlogPostCommentRepository;

        public int Likes { get; set; }
        public bool Liked { get; set; }
        public BlogPost BlogPost { get; set; }

        public List<BlogComments> BlogComments { get; set; }

        [BindProperty]
        public Guid BlogPostId { get; set; }

        [BindProperty]
        public string CommentDescription { get; set; }
        public detailsModel(
            IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository
            )
        {
            _blogPostRepository = blogPostRepository;
            _blogPostLikeRepository = blogPostLikeRepository;
            this._signInManager = signInManager;
            this._userManager = userManager;
            this._BlogPostCommentRepository = blogPostCommentRepository;
        }
        public async Task<IActionResult> OnGet(string UrlHandle)
        {
            BlogPost = await _blogPostRepository.GetBlogPostByUrlAsync(UrlHandle);
            if (BlogPost != null && BlogPost.Id != null)
            {
                BlogPostId = BlogPost.Id;
                Likes = await _blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);

                if (_signInManager.IsSignedIn(User))
                {
                    var likes = await _blogPostLikeRepository.GetLikesForBlog(BlogPost.Id);

                    var userId = _userManager.GetUserId(User);

                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));
                }
                await GetComments();
            }
            else
            {
                Likes = 0;
            }
            return Page();
        }
        public async Task<IActionResult> OnPost(string UrlHandle)
        {
            if (_signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
            {
                await _BlogPostCommentRepository.AddAsync(new BlogPostComment()
                {
                    BlogPostId = BlogPostId,
                    Description = CommentDescription,
                    DateAdded = DateTime.Now,
                    UserId = Guid.Parse(_userManager.GetUserId(User))
                });
            }
            return RedirectToPage("/blog/details", new { UrlHandle = UrlHandle });
        }
        
        private async Task GetComments()
        {
            var blogPostComments = await _BlogPostCommentRepository.GetAllAsync(BlogPostId);

            var blogCommentsViewModel = new List<BlogComments>();

            foreach (var blogPostComment in blogPostComments)
            {
                blogCommentsViewModel.Add(new BlogComments
                {
                    DateAdded = blogPostComment.DateAdded,
                    Description = blogPostComment.Description,
                    Username = (await _userManager.FindByIdAsync(blogPostComment.UserId.ToString())).UserName
                });
            }

            BlogComments = blogCommentsViewModel;
        }
    }
}
