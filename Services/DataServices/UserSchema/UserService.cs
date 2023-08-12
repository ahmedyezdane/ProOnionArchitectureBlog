using Common.ApiResult;
using Common.Exceptions;
using Core.UserSchema;
using Data;
using Data.Contracts.UserSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Services.DataServices.UserSchema;


public class UserService : Service, IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task DeleteUser(CancellationToken ct, int userId)
    {
        var user = await _context.Users.FindAsync(userId);

        if (user is null)
            throw new BadRequestException("No User found with the given userId");

        _context.Users.Remove(user);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<PaginatedResult<User>> GetUserAsync(CancellationToken ct, int pageId = 1, int take = 20, string userName = "")
    {
        var query = _context.Users.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userName))
            query = query.Where(x => x.UserName.ToLower() == userName.ToLower());

        var result = await query.Skip((pageId - 1) * take).Take(take).ToListAsync(ct);

        var filters = new Dictionary<string, string>() { { "userName", userName } };

        return new PaginatedResult<User>(result, pageId, take,filters);
    }

    public Task<User> GetUserAsync(CancellationToken ct, int userId)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateUserAsync(CancellationToken ct, User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync(ct);
    }
}
