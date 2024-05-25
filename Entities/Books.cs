using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using myProject.Entities.Basic;
using myProject.Utils.Enums;

namespace myProject.Entities;

public class Books : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int id { get; set; }
    public string thumbnail { get; set; }
    public string title { get; set; }
    public string author { get; set; }
    public string publisher { get; set; }
    public DateTimeOffset publish_date { get; set; } = DateTimeOffset.Now.AddHours(7);
    public string genre { get; set; }
    public int quantity { get; set; }
    
    public string? description { get; set; }
    public Enums.BookStatus status { get; set; } = Enums.BookStatus.INACTIVE;
}