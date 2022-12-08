using System.Globalization;
using MB.Application.Contracts.ArticleCategory;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application;

public class ArticleCategoryApplication : IArticleCategoryApplication
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;
    private readonly IArticleCategoryValidationService _articleCategoryValidationService;

    public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public List<ArticleCategoryViewModel> List()
    {
        var articleCategories = _articleCategoryRepository.GetAll();
        var result = new List<ArticleCategoryViewModel>();
        foreach (var ar in articleCategories)
        {
            result.Add(new ArticleCategoryViewModel()
            {
                Id = ar.Id,
                CreationDate = ar.CreationDate.ToString(CultureInfo.InvariantCulture),
                IsDeleted = ar.IsDeleted,
                Title = ar.Title
            });
        }

        return result;
    }

    public void Create(CreateArticleCategory command)
    {
        var articleCategory = new ArticleCategory(command.Title, _articleCategoryValidationService);
        _articleCategoryRepository.Add(articleCategory);
    }

    public void Rename(RenameArticleCategory command)
    {
        var articleCategory = _articleCategoryRepository.Get(command.Id);
        articleCategory.Rename(command.Title);
        _articleCategoryRepository.Save();
    }

    public RenameArticleCategory Get(long id)
    {
        var articleCateogry = _articleCategoryRepository.Get(id);
        return new RenameArticleCategory()
        {
            Id = articleCateogry.Id,
            Title = articleCateogry.Title
        };
    }

    public void Remove(long id)
    {
        var articleCategory=_articleCategoryRepository.Get(id);
        articleCategory.Remove();
        _articleCategoryRepository.Save();
        
    }

    public void Activate(long id)
    {
        var articleCateogry = _articleCategoryRepository.Get(id);
        articleCateogry.Activate();
        _articleCategoryRepository.Save();
    }
}
