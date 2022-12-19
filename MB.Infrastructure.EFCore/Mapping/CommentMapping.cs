using MB.Domain.ArticleAgg;
using MB.Domain.CommentsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping;

public class CommentMapping:IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.Article).WithMany(c => c.Comments).HasForeignKey(c => c.ArticleId);
    }
}