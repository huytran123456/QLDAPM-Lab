using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myProject.Config;
using myProject.Dtos.User;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Controllers.Api.Admin;

[Route("admin/api/user")]
[Authorize]
[ApiController]
public class AdminUserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public AdminUserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("list")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
    
    [HttpGet("list/{status}")]
    public IActionResult GetAllByStatus(Enums.UserStatus status)
    {
        var users = _userService.GetAllByStatus(status);
        return Ok(users);
    }
    
    [HttpGet("detail/{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }
    
    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _userService.Create(model);
        return Ok(new { message = "User created" });
    }

    [HttpPut("update-info/{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.UpdateInfo(id, model);
        return Ok(new { message = "User updated" });
    }
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}