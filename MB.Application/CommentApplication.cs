using MB.Application.Contracts.Comment;
using MB.Domain.CommentsAgg;

namespace MB.Application;

public class CommentApplication:ICommentApplication
{
    private readonly ICommentRepository _commentRepository;

    public CommentApplication(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }
}