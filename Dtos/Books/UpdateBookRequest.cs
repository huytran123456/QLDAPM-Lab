using myProject.Utils.Enums;

namespace myProject.Dtos.Books;

public class UpdateBookRequest
{
    public string title { get; set; }
    public string? thumbnail { get; set; }
    public string author { get; set; }
    public string publisher { get; set; }
    public DateTimeOffset publish_date { get; set; }
    public string genre { get; set; }
    public int quantity { get; set; }
    public string? description { get; set; }
    public Enums.BookStatus status { get; set; } = Enums.BookStatus.ACTIVE;
}