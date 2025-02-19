using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DemoTestController  : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Hello from API!" });
    }
}