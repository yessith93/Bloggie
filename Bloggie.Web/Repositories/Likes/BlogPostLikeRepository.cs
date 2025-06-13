using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Repositories.Likes
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggieDbContext _bloggieDbContext;
        public BlogPostLikeRepository(BloggieDbContext context)
        {
            _bloggieDbContext = context;
        }

        public async Task AddLikeForBlog(Guid BlogPostId, Guid UserId)
        {
            var newLike = new BlogPostLike()
            {
                Id = Guid.NewGuid(),
                BlogPostId = BlogPostId,
                UserId = UserId
            };
            await _bloggieDbContext.BlogPostLike.AddAsync(newLike);
            await _bloggieDbContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            int TotalLikes = await _bloggieDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
            return TotalLikes;
        }
    }
    
}
