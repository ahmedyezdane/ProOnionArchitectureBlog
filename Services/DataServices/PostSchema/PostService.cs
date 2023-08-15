using Common.ApiResult;
using Common.Exceptions;
using Core.PostSchema;
using Core.UserSchema;
using Data;
using Data.Contracts.PostSchema;
using Data.DTOs.PostSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

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

        using (var transaction = _context.Database.BeginTransaction())
        {
            try
            {
                _context.Comments.Where(c => c.PostId == postId).ExecuteDelete();
                _context.Posts.Remove(post);
                _context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public async Task<Post> GetPostByIdAsync(CancellationToken ct, int postId)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.PostId == postId, ct);
    }

    public async Task<Post> GetPostBySlugAsync(CancellationToken ct, string slug)
    {
        return await _context.Posts.FirstOrDefaultAsync(p => p.Slug == slug, ct);
    }

    public async Task<PaginatedResult<Post>> GetPostsAsync(CancellationToken ct, int pageId = 1, int take = 20, string title = "", bool includeDeleted = false)
    {
        var query = _context.Posts.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(title))
            query = query.Where(x => x.Title.ToLower().Contains(title.ToLower()));

        if (includeDeleted == false)
            query = query.Where(p => p.IsDeleted == false);

        var result = await query.Skip((pageId - 1) * take).Take(take).ToListAsync(ct);

        var filters = new Dictionary<string, string>() { { "title", title }, { "includeDeleted", includeDeleted.ToString() } };

        return new PaginatedResult<Post>(result, pageId, take, filters);
    }

    public async Task InsertPostAsync(InsertPostDto dto, int userId)
    {
        if (await _context.Posts.AnyAsync(p => p.Slug == dto.Slug))
            throw new BadRequestException("Duplication Slug Violation !!");

        // upload image
        var post = new Post()
        {
            Title = dto.Title,
            Slug = dto.Slug,
            Text = dto.Text,
            PictureName = "foo",
            UserId = userId
        };
        await _context.AddAsync(post);
        await _context.SaveChangesAsync();
    }

    public void UpdatePost(UpdatePostDto dto)
    {
        if (dto.Picture != null)
        {
            //update picture
        }

        _context.Update(dto);
        _context.SaveChanges();
    }

    #endregion

    #region Comment

    public async Task InsertCommentAsync(InsertCommentDto dto,int userId)
    {
        var comment = new Comment()
        {
            PostId = dto.PostId,
            UserId = userId,
            Text = dto.Text
        };

        await _context.AddAsync(comment);
        await _context.SaveChangesAsync();
    }

    public void DeleteComment(int commentId)
    {
        var comment = _context.Comments.FirstOrDefault(c => c.CommentId == commentId);

        if (comment is null)
            throw new NotFoundException("there is no comment with the given id");

        _context.Remove(comment);
        _context.SaveChanges();
    }

    public async Task<PaginatedResult<Comment>> GetCommentsOfPostAsync(CancellationToken ct, int postId, int pageId = 1, int take = 20, bool includeDeleted = false)
    {
        var query = _context.Comments.AsNoTracking().AsQueryable();

        if (includeDeleted == false)
            query = query.Where(p => p.IsDeleted == false);

        var result = await query.Skip((pageId - 1) * take).Take(take).ToListAsync(ct);

        var filters = new Dictionary<string, string>() {{ "includeDeleted", includeDeleted.ToString() } };

        return new PaginatedResult<Comment>(result, pageId, take, filters);
    }

    #endregion
}
