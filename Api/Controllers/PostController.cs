using Common.Exceptions;
using Data.Contracts.PostSchema;
using Data.DTOs.PostSchema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class PostController : BaseController
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [HttpGet]
    public async Task<IActionResult> GetPosts(CancellationToken ct, int pageId = 1, int take = 20, string title = "")
        => Ok(await _postService.GetPostsAsync(ct, pageId, take, title));

    [HttpGet("{postId:int}")]
    public async Task<IActionResult> GetPostById(CancellationToken ct, int postId)
    {
        if (postId == 0)
            throw new BadRequestException("Invalid PostId");

        var post = await _postService.GetPostByIdAsync(ct, postId);

        if(post is null)
            throw new NotFoundException("there is no post with the given id");

        return Ok(post);
    }

    [HttpGet("[action]/{slug}")]
    public async Task<IActionResult> GetPostBySlug(CancellationToken ct, string slug)
    {
        if (string.IsNullOrWhiteSpace(slug))
            throw new BadRequestException("slug is required");

        var post = await _postService.GetPostBySlugAsync(ct, slug);

        if (post is null)
            throw new NotFoundException("there is no post with the given slug");

        return Ok(post);
    }

    [HttpPost]
    //[Authorize]
    public async Task<IActionResult> InsertPost([FromForm] InsertPostDto postDto)
    {
        int userId = 1;
        await _postService.InsertPostAsync(postDto,userId);
        return Ok();
    }

    [HttpPut]
    //[Authorize]
    public IActionResult UpdatePost([FromForm] UpdatePostDto postDto)
    {
        _postService.UpdatePost(postDto);
        return Ok();
    }

    [HttpDelete("{postId:int}")]
    //[Authorize]
    public IActionResult DeletePost(int postId)
    {
        _postService.DeletePost(postId);
        return Ok();
    }

    [HttpGet("comments/{postId:int}")]
    public async Task<IActionResult> GetPostsOfComment(CancellationToken ct,int postId, int pageId = 1, int take = 20)
        => Ok(await _postService.GetCommentsOfPostAsync(ct, postId, pageId,take));

    [HttpPost("comments")]
    //[Authorize]
    public async Task<IActionResult> InsertComment(InsertCommentDto dto)
    {
        int userId = 1;
        await _postService.InsertCommentAsync(dto, userId);
        return Ok();
    }

    [HttpDelete("comments/{commentId:int}")]
    //[Authorize]
    public IActionResult DeleteComment(int commentId)
    {
        _postService.DeleteComment(commentId);
        return Ok();
    }
}
