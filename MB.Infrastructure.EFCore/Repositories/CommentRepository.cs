using System.Globalization;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentsAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EFCore.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly MasterBloggerContext _context;

    public CommentRepository(MasterBloggerContext context)
    {
        _context = context;
    }

    public void CreateAndSave(Comment entity)
    {
        _context.Comments.Add(entity);
        Save();
    }

    public List<CommentViewModel> GetList()
    {
       return _context.Comments.Include(c => c.Article).Select(c => new CommentViewModel
        {
            Id = c.Id,
            Name = c.Name,
            Email = c.Email,
            CreationDate = c.CreationDate.ToString(CultureInfo.InvariantCulture),
            Message = c.Message,
            Status = c.Status,
            Article = c.Article.Title
        }).ToList();
    }

    public Comment Get(long id)
    {
        return _context.Comments.FirstOrDefault(c=>c.Id == id);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}