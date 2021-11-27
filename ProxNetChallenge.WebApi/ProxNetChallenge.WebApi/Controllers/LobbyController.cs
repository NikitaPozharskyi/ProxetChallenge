using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxNetChallenge.Entities.models;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.WebApi.Controllers
{
    [Route("api/v1/lobby")]
    public class LobbyController : Controller
    {
        private readonly ILobbyService _lobbyService;
        public LobbyController(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        [HttpGet]
        public IActionResult Lobby()
        {
            return Ok();
        }

        [HttpPost("player")]
        public async Task<IActionResult> AddPlayerToLobby(Guid id)
        {
            await _lobbyService.AddPlayerToLobby(id);
            return Ok();
        }
    }
}
