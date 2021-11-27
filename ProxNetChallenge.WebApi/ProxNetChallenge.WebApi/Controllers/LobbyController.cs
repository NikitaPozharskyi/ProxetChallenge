using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxNetChallenge.Entities.models;

namespace ProxNetChallenge.WebApi.Controllers
{
    [Route("api/v1/lobby")]
    public class LobbyController : Controller
    {
        [HttpGet()]
        public IActionResult Lobby(string userName, Vehicle vehicle)
        {
            return Ok();
        }

        public Task<IActionResult> AddPlayerToLobby()
        {

        }
    }
}
