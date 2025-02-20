using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class DemoTestController  : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Wake up, Neo... The API has you." });
    }
}