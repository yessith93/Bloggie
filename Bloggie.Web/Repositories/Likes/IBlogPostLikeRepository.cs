using Bloggie.Web.Models.Domain;

namespace Bloggie.Web.Repositories.Likes
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid BlogPostId);
        Task AddLikeForBlog(Guid BlogPostId, Guid UserId);
        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
