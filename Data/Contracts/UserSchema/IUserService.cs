using Common.ApiResult;
using Core.UserSchema;

namespace Data.Contracts.UserSchema;

public interface IUserService : IService
{
    Task<PaginatedResult<User>> GetUserAsync(CancellationToken ct,int pageId = 1, int take = 20, string userName = "");
    Task<User> GetUserAsync(CancellationToken ct,int userId);
    void UpdateUser(User user);
    void DeleteUser(int userId);
}
