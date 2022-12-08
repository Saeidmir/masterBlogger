using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EFCore.Mapping;

public class ArticleMapping:IEntityTypeConfiguration<Article>
{
    public void Configure(EntityTypeBuilder<Article> builder)
    {
        builder.ToTable("Articles");
        builder.HasKey(a => a.Id);
        builder.HasOne(a => a.ArticleCategory).WithMany(a => a.Articles).HasForeignKey(a => a.ArticleCategoryId);
    }
}