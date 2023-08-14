using Common.ApiResult;
using Core.UserSchema;

namespace Data.Contracts.UserSchema;

public interface IUserService
{
    Task<PaginatedResult<User>> GetUsersAsync(CancellationToken ct,int pageId = 1, int take = 20, string userName = "");
    Task<User> GetUserByIdAsync(CancellationToken ct,int userId);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
