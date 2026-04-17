using Microsoft.AspNetCore.Mvc;

namespace RecycleManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get() => Ok(new { status = "API OK" });
}
