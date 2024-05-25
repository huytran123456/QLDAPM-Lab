using Microsoft.AspNetCore.Mvc;

namespace myProject.Controllers.UI;

public class AdminBorrowController : Controller
{
    private readonly ILogger<AdminBorrowController> _logger;

    public AdminBorrowController(ILogger<AdminBorrowController> logger)
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