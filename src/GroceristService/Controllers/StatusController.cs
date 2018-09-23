using Microsoft.AspNetCore.Mvc;

namespace GroceristService.Controllers
{
    [Route("")]
    [ApiController]
    public class StatusController : Controller
    {
        [HttpGet("Status")]
        public IActionResult HealthCheck()
        {
            return Ok();
        } 
    }
}
