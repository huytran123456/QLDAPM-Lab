using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myProject.Config;
using myProject.Dtos.Books;
using myProject.Service.Implements;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Controllers.Admin;

[Route("admin/api/books")]
[Authorize]
[ApiController]
public class AdminBookController : ControllerBase
{
    private BookService _bookService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;
    
    public AdminBookController(
        BookService bookService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _bookService = bookService;
        _mapper = mapper;
    }
    
    [HttpGet("list")]
    public IActionResult GetAll()
    {
        var books = _bookService.GetAll();
        return Ok(books);
    }
    
    [HttpGet("list/{status}")]
    public IActionResult GetAllByStatus(Enums.BookStatus status)
    {
        var books = _bookService.GetAllByStatus(status);
        return Ok(books);
    }
    
    [HttpGet("detail/{id}")]
    public IActionResult GetById(int id)
    {
        var book = _bookService.GetById(id);
        return Ok(book);
    }
    
    [HttpPost]
    public IActionResult Create(CreateBookRequest model)
    {
        _bookService.Create(model);
        return Ok(new { message = "Book created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateBookRequest model)
    {
        _bookService.Update(id, model);
        return Ok(new { message = "Book updated" });
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _bookService.Delete(id);
        return Ok(new { message = "Book deleted" });
    }
}