using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {

        public List<BlogPost> blogPosts;

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            BlogPostRepository = blogPostRepository;
        }

        public IBlogPostRepository BlogPostRepository { get; }

        public async Task OnGet()
        {
            var jsonNotification = (string)TempData["Notification"];
            if (jsonNotification!= null) { 

                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(jsonNotification); 

            }
            blogPosts = (await this.BlogPostRepository.GetAllBlogPostsAsync()).ToList();
        }
    }
}
