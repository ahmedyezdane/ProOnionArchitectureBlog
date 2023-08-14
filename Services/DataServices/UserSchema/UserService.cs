using Common.ApiResult;
using Common.Exceptions;
using Core.UserSchema;
using Data;
using Data.Contracts.UserSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Services.DataServices.UserSchema;


public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void DeleteUser(int userId)
    {
        var user = _context.Users.Find(userId);

        if (user is null)
            throw new BadRequestException("No User found with the given userId");

        _context.Remove(user);
        _context.SaveChanges();
    }

    public async Task<PaginatedResult<User>> GetUsersAsync(CancellationToken ct, int pageId = 1, int take = 20, string userName = "")
    {
        var query = _context.Users.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(userName))
            query = query.Where(x => x.UserName.ToLower() == userName.ToLower());

        var result = await query.Skip((pageId - 1) * take).Take(take).ToListAsync(ct);

        var filters = new Dictionary<string, string>() { { "userName", userName } };

        return new PaginatedResult<User>(result, pageId, take,filters);
    }

    public async Task<User> GetUserByIdAsync(CancellationToken ct, int userId)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId,ct);

        if (user is null)
            throw new NotFoundException("there is no user with the given userId");

        user.PasswordHash = null;
        return user;
    }

    public void UpdateUser(User user)
    {
        if(user.UserId != 0 && !_context.Users.Any(u => u.UserId == user.UserId))
            throw new NotFoundException("there is no user with the given userId");

        _context.Update(user);
        _context.SaveChanges();
    }
}
