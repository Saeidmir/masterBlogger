using System.Globalization;
using MB.Domain.CommentsAgg;
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
        return _context.Articles
            .Include(a => a.ArticleCategory)
            .Include(a=>a.Comments).Select(a => new ArticleQueryView()
        {
            Id = a.Id,
            Title = a.Title,
            Image = a.Image,
            ArticleCategory = a.ArticleCategory.Title,
            CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture),
            ShortDescription = a.ShortDescription,
            CommentsCount = a.Comments.Count(a=>a.Status == Statuses.Confirmed)
            
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
            Content = a.Content,
            CommentsCount = a.Comments.Count(a=>a.Status == Statuses.Confirmed),
            Comments = MapComments(a.Comments.Where(a=>a.Status == Statuses.Confirmed))
            
        }).FirstOrDefault(a=>a.Id==id);
    }

    private static List<CommentsQueryView> MapComments(IEnumerable<Comment> comments)
    {
        return comments.Select(comment => new CommentsQueryView()
            { Name = comment.Name, Message = comment.Message, CreationDate = comment.CreationDate.ToString(CultureInfo.InvariantCulture) }).ToList();
    }
}