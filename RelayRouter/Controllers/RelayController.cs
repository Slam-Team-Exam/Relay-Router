using Microsoft.AspNetCore.Mvc;

namespace RelayRouter.Controllers
{
    [ApiController]
    [Route("")]
    public class RelayController : ControllerBase
    {
        [HttpGet("health")]
        public async Task<IActionResult> Health()
        {
            return Ok();
        }


        [HttpPost("MakeConnection")]
        public async Task<IActionResult> FoundMatch([FromBody] string JWT)
        {
            return Ok();
        }
    }
}
