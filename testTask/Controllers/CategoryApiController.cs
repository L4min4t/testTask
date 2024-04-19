using Microsoft.AspNetCore.Mvc;
using testTask.Services.Interfaces;

namespace testTask.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryApiController : ControllerBase
{
    private readonly ICategoryService _service;

    public CategoryApiController(ICategoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _service.FindAllAsync());

    [HttpGet("inherit-available/{id?}")]
    public async Task<IActionResult> GetInheritAvailable([FromRoute] int id) => Ok(await _service
        .GetInheritAvailableCategoriesAsync(id));
}