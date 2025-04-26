using Azure;
using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModels;
using Bloggie.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {
        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }
        public IBlogPostRepository BlogPostRepository { get; }
        [BindProperty]
        public string Tags { get; set; }

        //create constructor 
        public AddModel(IBlogPostRepository blogPostRepository)
        {
            BlogPostRepository = blogPostRepository;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost() {
            BlogPost blogpost = new BlogPost()
            {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible,
                tags = new List<Tag>(Tags.Split(',').Select(x => new Tag() { Name = x.Trim() }))
            };
            await this.BlogPostRepository.AddBlogPostAsync(blogpost);
            var jsonNotification = new Notification()
            {
                Message = "BlogBost was successfully Created",
                Type = Enums.NotificationType.Success
            };

            TempData["Notification"] = JsonSerializer.Serialize(jsonNotification);


            return RedirectToPage("/admin/blogs/list");
        }
    }
}
