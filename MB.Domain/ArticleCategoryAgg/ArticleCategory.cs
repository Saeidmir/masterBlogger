using System.ComponentModel.DataAnnotations;
using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Domain.ArticleCategoryAgg;

public class ArticleCategory
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }
    public ICollection<Article> Articles { get; set; }

    public ArticleCategory(string title , IArticleCategoryValidationService validatorService)
    {
        GuardAgainstEmptyTitle(title);
        Title = title;
        IsDeleted = false;
        CreationDate = DateTime.Now;
        Articles = new List<Article>();
    }

    public void GuardAgainstEmptyTitle(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentNullException();
    }

    public void Rename(string title)
    {
        GuardAgainstEmptyTitle(title);
        Title = title;
    }

    public void Remove()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }
}