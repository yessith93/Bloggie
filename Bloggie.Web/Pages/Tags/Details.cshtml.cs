using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Tags
{
    public class DetailsModel : PageModel
    {
        public IBlogPostRepository _PostRepository { get; }
        public List<BlogPost> Blogs { get; set; }
        public DetailsModel(IBlogPostRepository postRepository)
        {
            _PostRepository = postRepository;
        }


        public async Task<IActionResult> OnGet(string TagName)
        {
            Blogs = (await _PostRepository.GetAllBlogPostsAsync(TagName)).ToList();
            return Page();
        }
    }
}
