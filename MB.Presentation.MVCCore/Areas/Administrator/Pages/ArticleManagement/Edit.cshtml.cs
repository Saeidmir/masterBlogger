using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Onion.Presentation.Areas.Administrator.Pages.ArticleManagement;

public class Edit : PageModel
{
    public Edit(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
    {
        _articleApplication = articleApplication;
        _articleCategoryApplication = articleCategoryApplication;
    }

    [BindProperty]
    public EditArticle Article {get;set;}
    public List<SelectListItem> ArticleCategories { get; set; }
    private readonly IArticleApplication _articleApplication;
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    

    public void OnGet(long id)
    {
         Article = _articleApplication.Get(id);
        ArticleCategories = _articleCategoryApplication.List()
            .Select(ac => new SelectListItem(ac.Title, ac.Id.ToString())).ToList();
    }

    public RedirectToPageResult OnPost()
    {
        _articleApplication.Edit(Article);
        return RedirectToPage("List");
    }
}