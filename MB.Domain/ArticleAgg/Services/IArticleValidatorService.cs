namespace MB.Domain.ArticleAgg.Services;

public interface IArticleValidatorService
{
    void checkRecordAlreadyExists(string title);
}