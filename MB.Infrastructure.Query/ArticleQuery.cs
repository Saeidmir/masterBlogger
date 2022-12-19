using System.Globalization;
using MB.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query;

public class ArticleQuery : IArticleQuery
{
    private readonly MasterBloggerContext _context;

    public ArticleQuery(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleQueryView> GetArticles()
    {
        return _context.Articles.Include(a => a.ArticleCategory).Select(a => new ArticleQueryView()
        {
            Id = a.Id,
            Title = a.Title,
            Image = a.Image,
            ArticleCategory = a.ArticleCategory.Title,
            CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = a.ShortDescription
        }).ToList();
    }

    public ArticleQueryView GetArticle(long id)
    {
        return _context.Articles.Include(a => a.ArticleCategory).Select(a => new ArticleQueryView()
        {
            Id = a.Id,
            Title = a.Title,
            Image = a.Image,
            ArticleCategory = a.ArticleCategory.Title,
            CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = a.ShortDescription,
            Content = a.Content
        }).FirstOrDefault(a=>a.Id==id);
    }
}