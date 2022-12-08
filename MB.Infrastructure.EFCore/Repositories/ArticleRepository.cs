﻿using MB.Application.Contracts.Article;

namespace MB.Infrastructure.EFCore.Repositories;

public class ArticleRepository:IArticleRepository
{
    private readonly MasterBloggerContext _context;

    public ArticleRepository(MasterBloggerContext context)
    {
        _context = context;
    }
}