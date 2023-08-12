using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

public class HomeController : BaseController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello There !");
    }
}
