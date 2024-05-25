using Microsoft.AspNetCore.Mvc;

namespace myProject.Controllers.UI;

public class AdminBookController : Controller
{
    private readonly ILogger<AdminBookController> _logger;

    public AdminBookController(ILogger<AdminBookController> logger)
    {
        _logger = logger;
    }

    public IActionResult List()
    {
        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Detail(int id)
    {
        return View();
    }
}