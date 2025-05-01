namespace Bloggie.Web.Repositories.Likes
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid BlogPostId);

    }
}
