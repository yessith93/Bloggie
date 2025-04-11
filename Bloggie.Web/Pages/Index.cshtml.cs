using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Bloggie.Web.Repositories;
using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBlogPostRepository _blogPostRepository;
        public List<BlogPost> Blogs { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository BlogPostRepository)
        {
            _logger = logger;
            _blogPostRepository = BlogPostRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await _blogPostRepository.GetAllBlogPostsAsync()).ToList();
            return Page();
        }
    }
}
