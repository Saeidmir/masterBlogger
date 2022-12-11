using MB.Application.Contracts.Article;
using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Onion.Presentation.Areas.Administrator.Pages.ArticleManagement;

public class Create : PageModel
{
    public Create(IArticleCategoryApplication articleCategoryApplication , IArticleApplication articleApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
        _articleApplication = articleApplication;
    }

    public List<SelectListItem> articleCategories { get; set; }
    private readonly IArticleCategoryApplication _articleCategoryApplication;
    private readonly IArticleApplication _articleApplication;
    
    public void OnGet()
    {
         articleCategories = _articleCategoryApplication.List()
            .Select(ac => new SelectListItem(ac.Title,ac.Id.ToString()))
            .ToList();
    }

    public RedirectToPageResult OnPost(CreateArticle command)
    {
        _articleApplication.Create(command);
        return RedirectToPage("List");
    }
}   