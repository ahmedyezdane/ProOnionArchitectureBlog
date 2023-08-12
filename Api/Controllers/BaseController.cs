using Microsoft.AspNetCore.Mvc;
using WebFramework.Filters;

namespace Api.Controllers;

// created to avoid repetition of attributes

[Route("api/[controller]")]
[ApiController]
[ApiResultFilter]
public class BaseController : ControllerBase { }
