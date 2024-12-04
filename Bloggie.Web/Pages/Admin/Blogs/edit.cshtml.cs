using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bloggie.Web.Pages.Admin.Blogs
{
    public class editModel : PageModel
    {
        [BindProperty]
        public BlogPost BlogPost { set; get; }
        private BloggieDbContext _context;

        public editModel(BloggieDbContext context)
        {
            _context = context;
        }

        public void OnGet(Guid id)
        {
            BlogPost = _context.BlogPosts.Find(id);
        }
        public IActionResult OnPostEdit()
        {
            BlogPost existingBlogpost = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlogpost != null)
            {
                existingBlogpost.Heading = BlogPost.Heading;
                existingBlogpost.PageTitle = BlogPost.PageTitle;
                existingBlogpost.Content = BlogPost.Content;
                existingBlogpost.ShortDescription = BlogPost.ShortDescription;
                existingBlogpost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogpost.UrlHandle = BlogPost.UrlHandle;
                existingBlogpost.PublishedDate = BlogPost.PublishedDate;
                existingBlogpost.Author = BlogPost.Author;
                existingBlogpost.Visible = BlogPost.Visible;
            }
            _context.SaveChanges();
            return RedirectToPage("/admin/blogs/list");
        }
        public IActionResult OnPostDelete()
        {
            BlogPost existingBlogpost = _context.BlogPosts.Find(BlogPost.Id);
            if (existingBlogpost != null)
            {
                _context.BlogPosts.Remove(existingBlogpost);
                _context.SaveChanges();
                return RedirectToPage("/admin/blogs/list");
            }
            return Page();
        }
    }
}
