using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testTask.Controllers;

public class CategoryController() : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}