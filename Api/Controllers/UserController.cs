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
        => Ok(await _userService.GetUserAsync(ct, pageId, take, userName));

    [HttpPost("[action]")]
    public async Task<IActionResult> RegisterUser(RegisterUserDto userDto, CancellationToken ct)
    {
        var user = new User()
        {
            BirthDate = DateTime.Now,
            UserId = 0,
            IsActive = true,
            Email = userDto.Email,
            FirstName = userDto.FirstName,
            Gender = userDto.Gender,
            LastName = userDto.LastName,
            PasswordHash = userDto.Password.GetSha256Hash(),
            UserName = userDto.UserName
        };

        await _userService.UpdateUserAsync(ct, user);

        return Ok();
    }
}
