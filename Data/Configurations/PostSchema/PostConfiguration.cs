using Core.PostSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.PostSchema;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts","Post");

        builder.HasKey(u => u.PostId);

        builder.Property(u => u.Title).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Text).IsRequired().HasMaxLength(4000);
        builder.Property(u => u.PictureName).IsRequired().HasMaxLength(100);
        builder.Property(u => u.Slug).IsRequired().HasMaxLength(100);
        builder.Property(u => u.CreationDate).IsRequired().HasDefaultValueSql("GetDate()");
        builder.Property(u => u.IsDeleted).IsRequired().HasDefaultValue(false);

        builder.HasMany(p => p.Comments).WithOne(p => p.Post).HasForeignKey(p => p.PostId);
    }
}
