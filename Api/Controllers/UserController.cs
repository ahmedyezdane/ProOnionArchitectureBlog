using Common.Exceptions;
using Common.Utilities;
using Core.UserSchema;
using Data.Contracts.UserSchema;
using Data.DTOs.UserSchema;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class UserController : BaseController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken ct, int pageId = 1, int take = 20, string userName = "")
        => Ok(await _userService.GetUsersAsync(ct, pageId, take, userName));

    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(CancellationToken ct, int userId)
    {
        if (userId == 0)
            throw new BadRequestException("Invalid UserId");

        var user = await _userService.GetUserByIdAsync(ct, userId);


        return Ok(user);
    }

    [HttpPost("[action]")]
    public IActionResult RegisterUser(RegisterUserDto userDto)
    {
        // RegisterUserDto converted to User with Implicit Operator in RegisterUserDto
        _userService.UpdateUser(userDto);
        return Ok();
    }

    [HttpPut]
    public IActionResult UpdateUser(UpdateUserDto userDto)
    {
        if (userDto.UserId == 0)
            throw new BadRequestException("Invalid UserId");

        // UpdateUserDto converted to User with Implicit Operator in UpdateUserDto
        _userService.UpdateUser(userDto);

        return Ok();
    }

    [HttpDelete("{userId:int}")]
    public IActionResult DeleteUser(int userId)
    {
        _userService.DeleteUser(userId);
        return Ok();
    }
}
