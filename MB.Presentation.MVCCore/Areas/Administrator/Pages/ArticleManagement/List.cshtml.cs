using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Onion.Presentation.Areas.Administrator.Pages.ArticleManagement;

public class List : PageModel
{
    public List(IArticleApplication articleApplication)
    {
        _ArticleApplication = articleApplication;
    }

    public List<ArticleViewModel> Articles { get; set; }
    public readonly IArticleApplication _ArticleApplication;
    public void OnGet()
    {
        Articles = _ArticleApplication.GetList();
    }

    public RedirectToPageResult OnPostRemove(long id)
    {
        _ArticleApplication.Remove(id);
        return RedirectToPage("List");
    }

    public RedirectToPageResult OnPostActivate(long id)
    {
        _ArticleApplication.Activate(id);
        return RedirectToPage("List");
    }
}