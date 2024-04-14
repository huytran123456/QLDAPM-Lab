using myProject.Dtos.Books;
using myProject.Entities;
using myProject.Utils.Enums;

namespace myProject.Service.Interfaces;

public interface IBookService
{
    IEnumerable<Books> GetAll();
    IEnumerable<Books> GetAllByStatus(Enums.BookStatus status);
    Books GetById(int id);
    BookResponse GetByIdAndStatus(int id);
    void Update(int id, UpdateBookRequest model);
    void Delete(int id);
    void Create(CreateBookRequest model);
}