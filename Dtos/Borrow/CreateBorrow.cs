using myProject.Utils.Enums;

namespace myProject.Dtos.Borrow;

public class CreateBorrow
{
    public int UserId { get; set; }
    
    public int BookId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public Enums.BorrowStatus status { get; set; } = Enums.BorrowStatus.PENDING;
}