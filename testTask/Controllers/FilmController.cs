using Microsoft.AspNetCore.Mvc;

namespace testTask.Controllers;

public class FilmController(ILogger<FilmController> logger) : Controller
{
    private readonly ILogger<FilmController> _logger = logger;

    public IActionResult Index()
    {
        return View();
    }

}