using Microsoft.AspNetCore.Mvc;
using testTask.Models;
using testTask.Services.Interfaces;

namespace testTask.Controllers;

public class FilmController : Controller
{
    private readonly IFilmService _service;

    public FilmController(IFilmService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index() => View(await _service.GetFilmViewModelsAsync());

    public async Task<IActionResult> View(int id) => View(await _service.GetFilmViewModelAsync(id));

    [HttpPost]
    public async Task<IActionResult> EditFilmCategories(EditFilmCategoriesModel editModel)
    {
        await _service.UpdateFilmCategoriesAsync(editModel);
        return RedirectToAction("View", "Film", new { id = editModel.Id });
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
    public async Task<IActionResult> Edit(int id) => View(await _service.GetEditFilmModel(id));

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

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}