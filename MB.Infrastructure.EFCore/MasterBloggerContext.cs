using System.Runtime.InteropServices.ComTypes;
using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore;

public class MasterBloggerContext: DbContext
{
    public DbSet<ArticleCategory> ArticleCategories { get; set; }
    public MasterBloggerContext(){}
    public MasterBloggerContext(DbContextOptions options) : base(options){ }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-B8RAO5T\\SQL2019;Initial Catalog=MasterBlogger;Encrypt=false;trusted_connection=true;MultipleActiveResultSets=True");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
        base.OnModelCreating(modelBuilder);
    }
}