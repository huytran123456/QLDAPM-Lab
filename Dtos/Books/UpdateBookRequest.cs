using myProject.Utils.Enums;

namespace myProject.Dtos.Books;

public class UpdateBookRequest
{
    public int category_id { get; set; } 
    public string title { get; set; }
    public string thumbnail { get; set; }
    public string author { get; set; }
    public string publisher { get; set; }
    public DateTimeOffset publish_date { get; set; }
    public string genre { get; set; }
    public string quantity { get; set; }
    public Enums.BookStatus status { get; set; } = Enums.BookStatus.ACTIVE;
}