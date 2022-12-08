using MB.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Areas.Administrator.Pages.ArticleCategoryManagement;

public class Create : PageModel
{
    private readonly IArticleCategoryApplication _articleCategoryApplication;

    public Create(IArticleCategoryApplication articleCategoryApplication)
    {
        _articleCategoryApplication = articleCategoryApplication;
    }

    public void OnGet()
    {
        
    }

    public IActionResult OnPost(CreateArticleCategory command)
    {
        _articleCategoryApplication.Create(command);
        return RedirectToPage("./List");
    }
}