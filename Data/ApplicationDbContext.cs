using Common.Utilities;
using Core;
using Core.PostSchema;
using Core.UserSchema;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users{ get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    public DbSet<Post> Posts{ get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var configurationsAssembly = typeof(ApplicationDbContext).Assembly;
        modelBuilder.RegisterEntityTypeConfiguration(configurationsAssembly);

        modelBuilder.AddRestrictDeleteBehaviorConvention();
        modelBuilder.AddSequentialGuidForIdConvention();
    }
}
