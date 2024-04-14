using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myProject.Dtos;

namespace myProject.Controllers.UI;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Profile()
    {
        return View();
    }
    
    public IActionResult Login()
    {
        return View();
    }
    
    public IActionResult Register()
    {
        return View();
    }
    
    public IActionResult VerifyRegister()
    {
        return View();
    }
    
    public IActionResult NotFound()
    {
        return View();
    }
}