using Bloggie.Web.Models.Domain;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Bloggie.Web.Pages.Blog
{
    public class detailsModel : PageModel
    {
        private readonly IBlogPostRepository _blogPostRepository;

        public BlogPost BlogPost { get; set; }
        public detailsModel(IBlogPostRepository blogPostRepository)
        {
            _blogPostRepository = blogPostRepository;
        }
        public async Task<IActionResult> OnGet(string UrlHandle)
        {
            BlogPost = await _blogPostRepository.GetBlogPostByUrlAsync(UrlHandle);
            return Page();
        }
    }
}
