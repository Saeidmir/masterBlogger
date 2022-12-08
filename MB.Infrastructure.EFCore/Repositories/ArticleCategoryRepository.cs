﻿using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleCategoryRepository:IArticleCategoryRepository
{
    private readonly MasterBloggerContext _context;


    public ArticleCategoryRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public List<ArticleCategory> GetAll()
    {
        return _context.ArticleCategories.OrderByDescending(a=>a.Id).ToList();
    }

    public void Add(ArticleCategory entity)
    {
        _context.ArticleCategories.Add(entity);
        Save();
    }

    public ArticleCategory Get(long id)
    {
        return _context.ArticleCategories.FirstOrDefault(c=>c.Id==id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

    public bool Exists(string title)
    {
        return _context.ArticleCategories.Any(ac=>ac.Title == title);
    }
}