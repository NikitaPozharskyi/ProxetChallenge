using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ProxNetChallenge.WebApi.Controllers
{
    
    [Route("api/v1/healthcheck")]
    public class HealthCheckController : Controller
    {
        [HttpGet()]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok("tut doljna bit logic about healthcheck");
        }
    }
}
