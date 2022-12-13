using System.Data;

namespace MB.Domain.ArticleAgg.Services;

public class ArticleValidatorService : IArticleValidatorService
{
    private readonly IArticleRepository _repository;

    public ArticleValidatorService(IArticleRepository repository)
    {
        _repository = repository;
    }

    public void checkRecordAlreadyExists(string title)
    {
        if (_repository.Exists(title))
        {
            throw new DuplicateNameException();
        }        
    }
}