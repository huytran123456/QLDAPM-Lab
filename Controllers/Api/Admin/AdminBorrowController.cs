using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myProject.Dtos.Borrow;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Controllers.Api.Admin;

[Route("admin/api/borrows")]
[Authorize]
[ApiController]
public class AdminBorrowController : ControllerBase
{
    private readonly IBorrowService _borrowService;

    public AdminBorrowController(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }

    [HttpGet("list")]
    public IActionResult GetAll()
    {
        var borrows = _borrowService.GetAll();
        return Ok(borrows);
    }

    [HttpGet("list/{status}")]
    public IActionResult GetAllByStatus(Enums.BorrowStatus status)
    {
        var borrows = _borrowService.GetAllByStatus(status);
        return Ok(borrows);
    }

    [HttpGet("detail/{id}")]
    public IActionResult GetById(int id)
    {
        var borrow = _borrowService.FindById(id);
        return Ok(borrow);
    }

    [HttpPost]
    public IActionResult Create(CreateBorrow model)
    {
        _borrowService.Create(model);
        return Ok(new { message = "Borrow created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateBorrow model)
    {
        _borrowService.Update(id, model);
        return Ok(new { message = "Borrow updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _borrowService.Delete(id);
        return Ok(new { message = "Borrow deleted" });
    }
}