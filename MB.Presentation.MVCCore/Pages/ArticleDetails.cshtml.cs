
using MB.Infrastructure.Query;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MB.Presentation.MVCCore.Pages
{
    public class ArticleDetailsModel : PageModel
    {
        public ArticleDetailsModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public ArticleQueryView Article { get; set; }
        private readonly IArticleQuery _articleQuery; 
        public void OnGet(long id)
        {
             Article = _articleQuery.GetArticle(id);
        }

        /*public RedirectToPageResult OnPost(AddComment command)
        {
            // _commentApplication.Add(command);
            // return RedirectToPage("./ArticleDetails", new {id = command.ArticleId});
        }*/
    }
}