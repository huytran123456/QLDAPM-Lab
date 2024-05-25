using myProject.Dtos.Borrow;
using myProject.Entities;
using myProject.Utils.Enums;

namespace myProject.Service.Interfaces;

public interface IBorrowService
{
    IEnumerable<object> GetAll();
    IEnumerable<object> GetAllByStatus(Enums.BorrowStatus status);
    BorrowResponse GetById(int id);
    Borrow FindById(int id);
    void Update(int id, UpdateBorrow model);
    void Delete(int id);
    void Create(CreateBorrow model);
}