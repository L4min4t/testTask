using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testTask.Controllers;

public class CategoryController(ILogger<CategoryController> logger) : Controller
{
    private readonly ILogger<CategoryController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}