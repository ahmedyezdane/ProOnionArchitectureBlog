using Common.Exceptions;
using Data.Contracts.PostSchema;
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

        return Ok(post);
    }

    [HttpPost("[action]")]
    public IActionResult CreatePost(CreatePostDto postDto)
    {
        _postService.CreatePost(postDto);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdatePost(UpdatePostDto postDto)
    {
        if (postDto.PostId == 0)
            throw new BadRequestException("Invalid PostId");

        _postService.UpdatePost(postDto);

        return Ok();
    }

    [HttpDelete("{postId:int}")]
    public IActionResult DeletePost(int postId)
    {
        _postService.DeletePost(postId);
        return Ok();
    }
}
