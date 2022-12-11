using MB.Domain.ArticleCategoryAgg.Exceptions;

namespace MB.Domain.ArticleCategoryAgg.Services;

public class ArticleCategoryValidationService : IArticleCategoryValidationService
{
    private readonly IArticleCategoryRepository _articleCategoryRepository;

    public ArticleCategoryValidationService(IArticleCategoryRepository articleCategoryRepository)
    {
        _articleCategoryRepository = articleCategoryRepository;
    }

    public void CheckThisRecordAlreadyExists(string title)
    {
        if (_articleCategoryRepository.Exists(title))
        {
            throw new DuplicateRecordException(message: "This record already is in db");
        };
    }
}