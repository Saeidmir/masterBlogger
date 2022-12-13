using System.Globalization;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleRepository : IArticleRepository
{
    private readonly MasterBloggerContext _context;

    public ArticleRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleViewModel> GetList()
    {
        return _context.Articles.Include(a => a.ArticleCategory).Select(a => new ArticleViewModel()
        {
            Id = a.Id,
            Title = a.Title,
            ArticleCategory = a.ArticleCategory.Title,
            IsDeleted = a.IsDeleted,
            CreationDate = a.CreationDate.ToString(CultureInfo.InvariantCulture)
        }).ToList();
    }

    public void CreateAndSave(Article entity)
    {
        _context.Articles.Add(entity);
        _context.SaveChanges();
    }

    public Article Get(long id)
    {
        return _context.Articles.FirstOrDefault(a => a.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool Exists(string title)
    {
        return _context.Articles.Any(a => a.Title == title);
    }
}