using Common.ApiResult;
using Core.PostSchema;

namespace Data.Contracts.PostSchema;

public interface IPostService : IService
{
    Task<PaginatedResult<Post>> GetPostAsync(int pageId = 1, int take = 20, string title = "");
    Task<Post> GetPostAsync(int postId);
    Task UpdatePostAsync(Post post);
    void DeletePost(int postId);
}
