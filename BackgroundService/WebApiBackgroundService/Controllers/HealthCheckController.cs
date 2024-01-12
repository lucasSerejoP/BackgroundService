using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiBackgroundService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"{DateTime.UtcNow:o}");
        }
    }
}
