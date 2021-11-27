using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.WebApi.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayer(Guid id)
        {
            if (id == Guid.Empty) return BadRequest(nameof(id));
            return Ok(await _playerService.GetPlayer(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetPlayer(string playerName)
        {
            if (String.IsNullOrWhiteSpace(playerName)) return BadRequest(nameof(playerName));
            return Ok(await _playerService.GetPlayer(playerName));
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(PlayerEntity entity)
        {
            if (entity == null) return BadRequest(nameof(entity));
            await _playerService.UpdatePlayer(entity);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(PlayerEntity entity)
        {
            if (entity == null) return BadRequest(nameof(entity));
            await _playerService.RemovePlayer(entity.Id);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser(string playerName)
        {
            if (String.IsNullOrWhiteSpace(playerName)) return BadRequest(nameof(playerName));
            await _playerService.RemovePlayer(playerName);
            return Ok();
        }

    }
}
