using MB.Application.Contracts.Comment;
using MB.Domain.CommentsAgg;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Onion.Presentation.Areas.Administrator.Pages.CommentManagement;

public class List : PageModel
{
    private readonly ICommentApplication _commentApplication;

    public List(ICommentApplication commentApplication)
    {
        _commentApplication = commentApplication;
    }

    public List<CommentViewModel> comments { get; set; }
    public void OnGet()
    {
        comments = _commentApplication.GetList();
    }

    public RedirectToPageResult OnPostConfirm(long id)
    {
        _commentApplication.Confirm(id);
        return RedirectToPage("List");
    }

    public RedirectToPageResult OnPostCancel(long id)
    {
        _commentApplication.Cancel(id);
        return RedirectToPage("List");
    }
}