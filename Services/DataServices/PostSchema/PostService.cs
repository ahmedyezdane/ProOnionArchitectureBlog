using Common.ApiResult;
using Common.Exceptions;
using Core.PostSchema;
using Core.UserSchema;
using Data;
using Data.Contracts.PostSchema;
using Data.DTOs.PostSchema;
using Microsoft.EntityFrameworkCore;

namespace Services.DataServices.PostSchema;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    #region Post

    public void DeletePost(int postId)
    {
        var post = _context.Posts.FirstOrDefault(x => x.PostId == postId);

        if (post is null)
            throw new NotFoundException("there is no post with the given id");

        using(var transaction = _context.Database.BeginTransaction())
        {

        }

        _context.Posts.Remove(post);
        _context.SaveChanges();
    }

    public Task<Post> GetPostByIdAsync(CancellationToken ct, int postId)
    {
        throw new NotImplementedException();
    }

    public Task<Post> GetPostBySlugAsync(CancellationToken ct, int postId)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResult<Post>> GetPostsAsync(CancellationToken ct, int pageId = 1, int take = 20, string title = "")
    {
        throw new NotImplementedException();
    }

    public Task InsertPostAsync(InsertPostDto dto)
    {
        throw new NotImplementedException();
    }

    public void UpdatePost(UpdatePostDto dto)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Comment

    public Task InsertCommentAsync(InsertCommentDto dto)
    {
        throw new NotImplementedException();
    }

    public void DeleteComment(int commentId)
    {
        throw new NotImplementedException();
    }

    public Task<PaginatedResult<Comment>> GetCommentsOfPostAsync(CancellationToken ct, int postId, int pageId = 1, int take = 20, bool includDeleted = false)
    {
        throw new NotImplementedException();
    }

    #endregion
}
