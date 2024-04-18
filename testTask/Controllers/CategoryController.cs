using Microsoft.AspNetCore.Mvc;
using testTask.Models;
using testTask.Services.Interfaces;

namespace testTask.Controllers;

public class CategoryController : Controller
{
    private readonly ICategoryService _service;

    public CategoryController(ICategoryService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index() => View(await _service.FindAllAsync());

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(CreateCategoryModel createCategoryModel)
    {
        if (ModelState.IsValid)
        {
            await _service.CreateAsync(createCategoryModel);
            return RedirectToAction("Index", "Category");
        }

        return View(createCategoryModel);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction("Index", "Category");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _service.FindByIdAsync(id);

        var editModel = new EditCategoryModel
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategoryId = category.ParentCategoryId,
        };

        return View(editModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(EditCategoryModel editModel)
    {
        if (ModelState.IsValid)
        {
            await _service.UpdateAsync(editModel);
            return RedirectToAction("Index", "Category");
        }

        return View(editModel);
    }
}