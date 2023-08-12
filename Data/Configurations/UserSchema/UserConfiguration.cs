using Core.UserSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.UserSchema;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users", "User");

        builder.HasKey(u => u.UserId);

        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
        builder.Property(u => u.UserName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.LastName).IsRequired().HasMaxLength(50);
        builder.Property(u => u.Gender).IsRequired();
        builder.Property(u => u.BirthDate).IsRequired().HasDefaultValueSql("GetDate()");
        builder.Property(u => u.IsActive).IsRequired().HasDefaultValue(0);

        builder.HasMany(u => u.Posts).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        builder.HasMany(u => u.Comments).WithOne(u => u.User).HasForeignKey(u => u.UserId);
        builder.HasMany(u => u.UserRoles).WithOne(u => u.User).HasForeignKey(u => u.UserId);
    }
}
