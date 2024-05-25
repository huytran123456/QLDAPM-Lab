using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myProject.Config;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Controllers;

[Route("api/books")]
[ApiController]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet("list")]
    public IActionResult? GetAll()
    {
        var books = _bookService.GetAllByStatus(Enums.BookStatus.ACTIVE);
        return Ok(books);
    }
    
    [HttpGet("detail/{id}")]
    public IActionResult? GetById(int id)
    {
        var book = _bookService.GetByIdAndStatus(id);
        return Ok(book);
    }
}