using Microsoft.AspNetCore.Mvc;

namespace testTask.Controllers;

public class ErrorController : Controller
{
    public IActionResult Error() => View();
}