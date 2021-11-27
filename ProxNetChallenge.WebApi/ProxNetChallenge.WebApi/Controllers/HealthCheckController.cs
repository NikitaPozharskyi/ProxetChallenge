using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProxNetChallenge.Services;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.WebApi.Controllers
{

    [Route("api/v1/healthcheck")]
    public class HealthCheckController : Controller
    {
        private readonly IPlayerService _playerService;
        public HealthCheckController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet()]
        public IActionResult HealthCheck()
        {
            if (!_playerService.IsHealthy()) return BadRequest();
            return Ok();

        }
    }
}
