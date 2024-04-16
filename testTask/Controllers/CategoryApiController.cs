using Microsoft.AspNetCore.Mvc;
using testTask.Entities;
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
}