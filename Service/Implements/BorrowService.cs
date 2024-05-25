using AutoMapper;
using myProject.Context;
using myProject.Dtos.Borrow;
using myProject.Entities;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Service.Implements;

public class BorrowService : IBorrowService
{
    private readonly SQLServerDBContext _context;
    private readonly IMapper _mapper;

    public BorrowService(
        SQLServerDBContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<object> GetAll()
    {
        var borrows = _context.Borrows
            .Where(v => v.status != Enums.BorrowStatus.DELETED)
            .Select(borrow => new
            {
                Borrow = borrow,
                User = _context.User.FirstOrDefault(u => u.id == borrow.UserId),
                Book = _context.Books.FirstOrDefault(u => u.id == borrow.BookId),
            })
            .ToList();

        return borrows;
    }

    public IEnumerable<object> GetAllByStatus(Enums.BorrowStatus status)
    {
        var borrows = _context.Borrows
            .Where(v => v.status == status)
            .Select(borrow => new
            {
                Borrow = borrow,
                User = _context.User.FirstOrDefault(u => u.id == borrow.UserId),
                Book = _context.Books.FirstOrDefault(u => u.id == borrow.BookId),
            })
            .ToList();

        return borrows;
    }

    public BorrowResponse GetById(int id)
    {
        return GetBorrowById(id);
    }

    public Borrow FindById(int id)
    {
        var borrow = _context.Borrows.Find(id);
        if (borrow == null)
            throw new KeyNotFoundException("Borrow not found");
        return borrow;
    }

    public void Update(int id, UpdateBorrow model)
    {
        var borrow = GetBorrow(id);

        borrow.UpdatedAt = DateTimeOffset.Now.AddHours(7);
        _mapper.Map(model, borrow);
        _context.Borrows.Update(borrow);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var borrow = GetBorrow(id);
        borrow.status = Enums.BorrowStatus.DELETED;
        borrow.DeletedAt = DateTimeOffset.Now.AddHours(7);
        _context.Borrows.Update(borrow);
        _context.SaveChanges();
    }

    public void Create(CreateBorrow model)
    {
        var borrow = _mapper.Map<Borrow>(model);
        borrow.CreatedAt = DateTimeOffset.Now.AddHours(7);
        borrow.status = Enums.BorrowStatus.RENT;
        _context.Borrows.Add(borrow);
        _context.SaveChanges();
    }

    private Borrow GetBorrow(int id)
    {
        var borrow = _context.Borrows.Find(id);
        if (borrow == null)
            throw new KeyNotFoundException("Borrow not found");
        return borrow;
    }

    private BorrowResponse GetBorrowById(int id)
    {
        var borrow = _context.Borrows.Find(id);
        if (borrow == null)
            throw new KeyNotFoundException("Borrow not found");
        var response = _mapper.Map<BorrowResponse>(borrow);
        return response;
    }
}