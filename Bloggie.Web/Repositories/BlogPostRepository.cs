using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BloggieDbContext _bloggieDbContext;
        public BlogPostRepository(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }
        public async Task<BlogPost> AddBlogPostAsync(BlogPost blogPost)
        {
            await _bloggieDbContext.BlogPosts.AddAsync(blogPost);
            await _bloggieDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteBlogPostAsync(Guid id)
        {
            BlogPost existingBlogpost = await _bloggieDbContext.BlogPosts.FindAsync(id);
            if (existingBlogpost != null)
            {
                _bloggieDbContext.BlogPosts.Remove(existingBlogpost);
                await _bloggieDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllBlogPostsAsync()
        {
            return await _bloggieDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetBlogPostByIdAsync(Guid id)
        {
            return await _bloggieDbContext.BlogPosts.FindAsync(id);
        }

        public async Task<BlogPost> UpdateBlogPostAsync(BlogPost blogPost)
        {
            BlogPost? existingBlogpost = await _bloggieDbContext.BlogPosts.FindAsync(blogPost?.Id);
            if (existingBlogpost != null)
            {
                existingBlogpost.Heading = blogPost.Heading;
                existingBlogpost.PageTitle = blogPost.PageTitle;
                existingBlogpost.Content = blogPost.Content;
                existingBlogpost.ShortDescription = blogPost.ShortDescription;
                existingBlogpost.FeaturedImageUrl = blogPost.FeaturedImageUrl;
                existingBlogpost.UrlHandle = blogPost.UrlHandle;
                existingBlogpost.PublishedDate = blogPost.PublishedDate;
                existingBlogpost.Author = blogPost.Author;
                existingBlogpost.Visible = blogPost.Visible;
            }
            await _bloggieDbContext.SaveChangesAsync();
            return existingBlogpost;
        }
    }
}
