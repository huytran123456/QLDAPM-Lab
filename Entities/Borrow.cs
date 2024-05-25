using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using myProject.Entities.Basic;
using myProject.Utils.Enums;

namespace myProject.Entities;

public class Borrow : BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [ForeignKey("User")] 
    public int UserId { get; set; }
    public virtual User User { get; set; }

    [ForeignKey("Book")] 
    public int BookId { get; set; }
    public virtual Books Book { get; set; }

    public DateTime BorrowDate { get; set; }
    public DateTime ReturnDate { get; set; }
    public Enums.BorrowStatus status { get; set; } = Enums.BorrowStatus.PENDING;
}