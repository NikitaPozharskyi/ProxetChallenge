using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxNetChallenge.Entities.models;
using ProxNetChallenge.Services;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.WebApi.Controllers
{
    [Route("api/v1/lobby")]
    public class LobbyController : Controller
    {
        private readonly IPlayerService _playerService;
        public LobbyController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet()]
        public IActionResult Lobby(string userName, Vehicle vehicle)
        {
            return Ok();
        }

        [HttpPost("player")]
        public Task<IActionResult> AddPlayerToLobby(Guid id)
        {
            _playerService
        }
    }
}
