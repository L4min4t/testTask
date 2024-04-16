using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace testTask.Controllers;

public class FilmController(ILogger<FilmController> logger) : Controller
{
    private readonly ILogger<FilmController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }
}