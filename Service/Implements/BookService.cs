using AutoMapper;
using myProject.Config;
using myProject.Context;
using myProject.Dtos.Books;
using myProject.Entities;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Service.Implements;

public class BookService : IBookService
{
    private readonly SQLServerDBContext _context;
    private readonly IMapper _mapper;

    public BookService(
        SQLServerDBContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Books> GetAll()
    {
        return _context.Books.Where(v => v.status != Enums.BookStatus.DELETED).ToList();
    }

    public IEnumerable<Books> GetAllByStatus(Enums.BookStatus status)
    {
        status = Enums.BookStatus.ACTIVE;
        return _context.Books.Where(v => v.status == status).ToList();
    }

    public Books GetById(int id)
    {
        return GetBooks(id);
    }

    public BookResponse GetByIdAndStatus(int id)
    {
        return GetBooksByIdAndStatus(id);
    }

    public void Update(int id, UpdateBookRequest model)
    {
        var book = GetBooks(id);
        model.thumbnail ??= book.thumbnail;
        book.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        _mapper.Map(model, book);
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var book = GetBooks(id);
        book.status = Enums.BookStatus.DELETED;
        book.DeletedAt = DateTimeOffset.Now.AddHours(7);
        _context.Books.Update(book);
        _context.SaveChanges();
    }

    public void Create(CreateBookRequest model)
    {
        var book = _mapper.Map<Books>(model);

        if (model.title == null)
        {
            throw new AppException("Title invalid!");
        }

        book.CreatedAt = DateTimeOffset.Now.AddHours(7);

        _context.Books.Add(book);
        _context.SaveChanges();
    }

    private Books GetBooks(int id)
    {
        var books = _context.Books.Find(id);
        if (books == null || books.status == Enums.BookStatus.DELETED)
            throw new KeyNotFoundException("Books not found");
        return books;
    }

    private BookResponse GetBooksByIdAndStatus(int id)
    {
        var books = _context.Books.Find(id);
        if (books == null || books.status != Enums.BookStatus.ACTIVE)
            throw new KeyNotFoundException("Books not found");
        var response = _mapper.Map<BookResponse>(books);
        return response;
    }
}