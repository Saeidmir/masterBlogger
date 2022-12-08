namespace MB.Domain.ArticleCategoryAgg.Exceptions;

public class DuplicateRecordException:Exception
{
    public DuplicateRecordException()
    {
        
    }

    public DuplicateRecordException(string message):base(message)
    {
        
    }
    
}