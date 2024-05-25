using myProject.Dtos.Books;
using myProject.Dtos.User;
using myProject.Utils.Enums;

namespace myProject.Dtos.Borrow;

public class BorrowResponse
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public UserResponse User { get; set; }
    public int BookId { get; set; }

    public BookResponse Book { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime ReturnDate { get; set; }

    public Enums.BorrowStatus status { get; set; }
}