namespace MB.Domain.CommentsAgg;
public interface ICommentRepository
{
    
    void CreateAndSave(Comment entity);
    List<CommentViewModel> GetList();
    Comment Get(long id);
    void Save();
}

