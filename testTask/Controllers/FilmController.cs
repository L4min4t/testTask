using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using testTask.Entities;
using testTask.Models;
using testTask.Repositories.Interfaces;
using testTask.Services.Interfaces;

namespace testTask.Controllers;

public class FilmController : Controller
{
    private readonly IFilmService _service;

    public FilmController (IFilmService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var films = await _service.FindAllAsync();
        
        return View(films);
    } 

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateFilmModel filmModel)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateAsync(filmModel);
            return RedirectToAction(nameof(Index));
        }

        return View(filmModel);
    }
}