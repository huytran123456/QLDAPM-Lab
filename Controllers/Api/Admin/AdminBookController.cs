using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myProject.Config;
using myProject.Dtos.Books;
using myProject.Service.Implements;
using myProject.Service.Interfaces;
using myProject.UploadFile.UploadMiniFile;
using myProject.Utils.Enums;

namespace myProject.Controllers.Api.Admin;

[Route("admin/api/books")]
[Authorize]
[ApiController]
public class AdminBookController : ControllerBase
{
    private readonly IBookService _bookService;
    readonly IBufferedFileUploadService _bufferedFileUploadService;

    public AdminBookController(
        IBookService bookService,
        IBufferedFileUploadService bufferedFileUploadService)
    {
        _bookService = bookService;
        _bufferedFileUploadService = bufferedFileUploadService;
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
    public async Task<IActionResult> Create([FromForm] CreateBookRequest model, IFormFile file)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string fileName = await _bufferedFileUploadService.UploadFile(file);
            model.thumbnail = fileName;
            _bookService.Create(model);
            return Ok(new { message = "Book created" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromForm] UpdateBookRequest model, IFormFile? file)
    {
        if (file != null && file.Length > 0)
        {
            var fileName = await _bufferedFileUploadService.UploadFile(file);
            model.thumbnail = fileName;
        }

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