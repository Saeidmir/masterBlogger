using MB.Domain.ArticleAgg;

namespace MB.Application.Contracts.Article;

public interface IArticleApplication
{
    List<ArticleViewModel> GetList();
    void Create( CreateArticle command);
}