using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync();
        Task<BlogPost> GetBlogPostByIdAsync(Guid id);
        Task<BlogPost> GetBlogPostByUrlAsync(string UrlHandle);
        Task<BlogPost> AddBlogPostAsync(BlogPost blogPost);
        Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost);
        Task<bool> DeleteBlogPostAsync(Guid id);
    }
}
