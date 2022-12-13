namespace MB.Domain.ArticleAgg;

public interface IArticleRepository
{
    List<ArticleViewModel> GetList();
    void CreateAndSave(Article entity);
    Article Get(long Id);
    void Save();
}