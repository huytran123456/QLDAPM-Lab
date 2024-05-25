namespace myProject.Entities.Basic;

public class BaseEntity
{
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now.AddHours(7);
    public int? CreatedBy { get; set; } 
    public DateTimeOffset? UpdatedAt { get; set; } 
    public  int?  UpdatedBy { get; set; }
    public DateTimeOffset? DeletedAt { get; set; } 
    public int? DeletedBy { get; set; } 
}