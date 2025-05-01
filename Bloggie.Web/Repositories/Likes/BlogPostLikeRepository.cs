using Bloggie.Web.Data;
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
        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            int TotalLikes = await _bloggieDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
            return TotalLikes;
        }
    }
    
}
