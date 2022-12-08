﻿using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg;

public class Article
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Image { get; private set; }
    public string ImageContent { get; private set; }
    public bool IsDelete { get; private set; }
    public DateTime CreationDate { get; private set; }
    public long ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }
    protected Article(){}

    public Article(string title, string shortDescription, string image, string imageContent, long articleCategoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        ImageContent = imageContent;
        ArticleCategoryId = articleCategoryId;
        IsDelete = false;
            CreationDate = DateTime.Now;;
    }
}