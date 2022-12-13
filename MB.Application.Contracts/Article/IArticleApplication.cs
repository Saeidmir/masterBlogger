using System.Collections.Generic;
using MB.Domain.ArticleAgg;

namespace MB.Application.Contracts.Article;

public interface IArticleApplication
{
    List<ArticleViewModel> GetList();
    void Create( CreateArticle command);
    void Edit(EditArticle command);
    EditArticle Get(long id);
    void Remove(long id);
    void Activate(long id);
}

public class EditArticle : CreateArticle
{
    public long Id { get; set; }

}