using Core.PostSchema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations.PostSchema;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments", "Post");

        builder.HasKey(u => u.CommentId);

        builder.Property(u => u.Text).IsRequired().HasMaxLength(1000);
        builder.Property(u => u.SubmitionDate).IsRequired().HasDefaultValueSql("GetDate()");
        builder.Property(u => u.IsDeleted).IsRequired().HasDefaultValue(0);
    }
}
