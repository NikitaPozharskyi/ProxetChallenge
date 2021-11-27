using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProxNetChallenge.Services.Interfaces;
using ProxNetChallenge.WebModels;

namespace ProxNetChallenge.WebApi.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ILobbyService _lobbyService;
        public TeamsController(ILobbyService lobbyService)
        {
            _lobbyService = lobbyService;
        }

        [HttpGet]
        public async Task<IActionResult> Generate()
        {
            var (firstTeam, secondTeam) = await _lobbyService.GenerateTeams();
            var mappedFirstTeam = await _lobbyService.MapPlayers(firstTeam);
            var mappedSecondTeam = await _lobbyService.MapPlayers(secondTeam);

            var teams = new PlayerTeamsModel { FirstTeam = mappedFirstTeam, SecondTeam = mappedSecondTeam };
            return Ok(teams);
        }

    }
}
