using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentsAgg;

namespace MB.Domain.ArticleAgg;

public class Article
{
    public long Id { get; private set; }
    public string Title { get; private set; }
    public string ShortDescription { get; private set; }
    public string Image { get; private set; }
    public string Content { get; private set; }
    public bool IsDeleted { get; private set; }
    public DateTime CreationDate { get; private set; }
    public long ArticleCategoryId { get; private set; }
    public ArticleCategory ArticleCategory { get; private set; }
    public ICollection<Comment> Comments { get;  set; }
    protected Article(){}

    public Article(string title, string shortDescription, string image, string content, long articleCategoryId)
    {
        // ValidateArticle(title, articleCategoryId);
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
        IsDeleted = false;
        CreationDate = DateTime.Now;
        Comments = new List<Comment>();
    }

    private static void ValidateArticle(string title, long articleCategoryId)
    {
        ValidateArticle(title, articleCategoryId);
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentNullException();
        }

        if (articleCategoryId == 0)
        {
            throw new ArgumentOutOfRangeException();
        }
    }

    public void Edit(string title, string shortDescription, string image, string content, long articleCategoryId)
    {
        Title = title;
        ShortDescription = shortDescription;
        Image = image;
        Content = content;
        ArticleCategoryId = articleCategoryId;
    }

    public void Remove()
    {
        IsDeleted = true;
    }

    public void Activate()
    {
        IsDeleted = false;
    }
}