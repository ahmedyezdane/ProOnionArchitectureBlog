using Common.ApiResult;
using Core.PostSchema;
using Data.DTOs.PostSchema;

namespace Data.Contracts.PostSchema;

public interface IPostService
{
    Task<PaginatedResult<Post>> GetPostsAsync(CancellationToken ct,int pageId = 1, int take = 20, string title = "",bool includeDeleted = false);
    Task<Post> GetPostByIdAsync(CancellationToken ct,int postId);
    Task<Post> GetPostBySlugAsync(CancellationToken ct, string slug);
    void UpdatePost(UpdatePostDto dto);
    Task InsertPostAsync(InsertPostDto dto,int userId);
    void DeletePost(int postId);

    Task InsertCommentAsync(InsertCommentDto dto,int userId);
    Task<PaginatedResult<Comment>> GetCommentsOfPostAsync(CancellationToken ct,int postId,int pageId = 1, int take = 20,bool includDeleted = false);
    void DeleteComment(int commentId);
}
