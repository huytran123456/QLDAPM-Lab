namespace myProject.Dtos.Books;

public class BookResponse
{
    public int id { get; set; }
    public int category_id { get; set; } = 1;
    public string title { get; set; }
    public string author { get; set; }
    public string publisher { get; set; }
    public string thumbnail { get; set; }
    public DateTimeOffset publish_date { get; set; }
    public string genre { get; set; }
    public string quantity { get; set; }
    public string status { get; set; }
}