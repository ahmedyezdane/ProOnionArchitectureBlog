using Common.ApiResult;
using Core.PostSchema;
using Data.DTOs.PostSchema;

namespace Data.Contracts.PostSchema;

public interface IPostService
{
    Task<PaginatedResult<Post>> GetPostsAsync(CancellationToken ct,int pageId = 1, int take = 20, string title = "");
    Task<Post> GetPostByIdAsync(CancellationToken ct,int postId);
    Task<Post> GetPostBySlugAsync(CancellationToken ct,int postId);
    void UpdatePost(UpdatePostDto dto);
    Task InsertPostAsync(InsertPostDto dto);
    void DeletePost(int postId);

    Task InsertCommentAsync(InsertCommentDto dto);
    Task<PaginatedResult<Comment>> GetCommentsOfPostAsync(CancellationToken ct,int postId,int pageId = 1, int take = 20,bool includDeleted = false);
    void DeleteComment(int commentId);
}
