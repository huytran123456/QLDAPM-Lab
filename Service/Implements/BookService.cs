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
    private MySQLDBContext _context;
    private readonly IMapper _mapper;
    
    public BookService(
        MySQLDBContext context,
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
        return getBooks(id);
    }

    public BookResponse GetByIdAndStatus(int id)
    {
        return getBooksByIdAndStatus(id);
    }

    public void Update(int id, UpdateBookRequest model)
    {
        var Books = getBooks(id);
        
        if(model.title == null)
            throw new AppException("Title invalid!");
        Books.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        var categories = _context.Categories.Find(model.category_id);
        if (categories == null)
        {
            throw new KeyNotFoundException("Categories not found");
        }
        _mapper.Map(model, Books);
        _context.Books.Update(Books);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var Books = getBooks(id);
        Books.status = Enums.BookStatus.DELETED;
        Books.DeletedAt = DateTimeOffset.Now.AddHours(7);
        _context.Books.Update(Books);
        _context.SaveChanges();
    }

    public void Create(CreateBookRequest model)
    {
        var Books = _mapper.Map<Books>(model);

        if (model.title == null)
        {
            throw new AppException("Title invalid!");
        }
        var categories = _context.Categories.Find(model.category_id);
        if (categories == null)
        {
            throw new KeyNotFoundException("Categories not found");
        }
        Books.CreatedAt = DateTimeOffset.Now.AddHours(7);

        _context.Books.Add(Books);
        _context.SaveChanges();
    }
    
    private Books getBooks(int id)
    {
        var Books = _context.Books.Find(id);
        if (Books == null || Books.status == Enums.BookStatus.DELETED) 
            throw new KeyNotFoundException("Insurance not found");
        return Books;
    }
    
    private BookResponse getBooksByIdAndStatus(int id)
    {
        var Books = _context.Books.Find(id);
        if (Books == null || Books.status != Enums.BookStatus.ACTIVE) 
            throw new KeyNotFoundException("Insurance not found");
        var category = _context.Categories.Find(Books.category_id);
        if (category == null)
        {
            throw new KeyNotFoundException("Insurance not found"); 
        }
        var response = _mapper.Map<BookResponse>(Books);
        return response;
    }
}