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

    public FilmController(IFilmService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index(string sortOrder)
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

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var film = await _service.FindByIdAsync(id);

        var editModel = new EditFilmModel
        {
            Id = film.Id,
            Name = film.Name,
            Director = film.Director,
            Release = film.Release,
            FilmCategories = film.Categories.Select(fc => fc.Id).ToList()
        };

        return View(editModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditFilmModel editModel)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(editModel);
            return RedirectToAction("View", "Film", new { id = editModel.Id });
        }

        return View(editModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditCategories(EditFilmModel editModel)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(editModel);
            return RedirectToAction("View", "Film", new { id = editModel.Id });
        }

        return RedirectToAction("View", "Film", new { id = editModel.Id });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> View(int id)
    {
        var film = await _service.FindByIdAsync(id);
        return View(film);
    }
}