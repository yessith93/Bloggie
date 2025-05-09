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
        private readonly ITagRepository _TagRepository;
        public List<BlogPost> Blogs { get; set; }
        public List<Tag> Tags { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IBlogPostRepository BlogPostRepository,ITagRepository tagRepository)
        {
            _logger = logger;
            _blogPostRepository = BlogPostRepository;
            _TagRepository = tagRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            Blogs = (await _blogPostRepository.GetAllBlogPostsAsync()).ToList();
            Tags = (await _TagRepository.GetAllAsync()).ToList();
            return Page();
        }
    }
}
