namespace MB.Domain.ArticleCategoryAgg.Services;

public interface IArticleCategoryValidationService
{
    void CheckThisRecordAlreadyExists(string title);

}