using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using myProject.Config;
using myProject.Dtos.User;
using myProject.Service.Interfaces;
using myProject.Utils.Enums;

namespace myProject.Controllers;

[Route("api/user")]
[Authorize]
[ApiController]
public class UserController : ControllerBase
{
    private IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }
    
    [HttpGet("list")]
    public IActionResult GetAll()
    {
        var users = _userService.GetAllByStatus(Enums.UserStatus.ACTIVE);
        return Ok(users);
    }
    
    [HttpGet("detail/{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetByIdAndStatus(id);
        return Ok(user);
    }
    
    [HttpPut("change-pass/{id}")]
    public IActionResult ChangPass(int id, ChangePasswordRequest model)
    {
        _userService.ChangPass(id, model);
        return Ok(new { message = "Change Password Success!" });
    }
    
    [HttpPut("update-info/{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.UpdateInfo(id, model);
        return Ok(new { message = "User updated" });
    }
}