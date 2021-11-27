using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProxNetChallenge.ProjectModels;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.WebApi.Controllers
{
    public class TeamsController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamsController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public async Task<Teams> Generate()
        {
            var (firstTeam, secondTeam) = await _teamService.GetTeamsToLobby();
            var teams = new Teams {FirstTeam = firstTeam, SecondTeam = secondTeam};
            return teams;

        }
    }
}
