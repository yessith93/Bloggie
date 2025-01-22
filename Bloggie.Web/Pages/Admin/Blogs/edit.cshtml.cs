using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class editModel : PageModel
    {
        [BindProperty]
        public BlogPost? BlogPost { set; get; }
        public IBlogPostRepository BlogPostRepository { get; }

        public editModel(IBlogPostRepository BlogPostRepository)
        {
            this.BlogPostRepository = BlogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            BlogPost = await this.BlogPostRepository.GetBlogPostByIdAsync(id);
        }
        public async Task<IActionResult> OnPostEdit()
        {
            try
            {
                await this.BlogPostRepository.UpdateBlogPostAsync(BlogPost);
                ViewData["Notification"] = new Notification()
                {
                    Message = "Record was successfully saved",
                    Type = Enums.NotificationType.Success
                };
            }
            catch (Exception)
            {
                ViewData["Notification"] = new Notification()
                {
                    Message = "Something went wrong!",
                    Type = Enums.NotificationType.Error
                };
            }
            return Page();
            //return RedirectToPage("/admin/blogs/list",ViewData);
        }
        public async Task<IActionResult> OnPostDelete()
        {
            bool deleted =  await this.BlogPostRepository.DeleteBlogPostAsync(BlogPost.Id);
            if (deleted)
        {
                var jsonNotification = new Notification()
            {
                    Message = "BlogBost was successfully Deleted",
                    Type = Enums.NotificationType.Info
                };

                TempData["Notification"] = JsonSerializer.Serialize(jsonNotification);
                return RedirectToPage("/admin/blogs/list");
            }
            return Page();
        }
    }
}
