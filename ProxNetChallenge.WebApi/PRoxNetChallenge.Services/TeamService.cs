using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Models;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.Services
{
    public class TeamService : ITeamService
    {
        private readonly IPlayerRepository _playerRepository;

        public TeamService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<(List<PlayerEntity>, List<PlayerEntity>)> GetTeamsToLobby()
        {
            var firstTeam = await GenerateTeam();
            var secondTeam = await GenerateTeam();

            return (firstTeam, secondTeam);
        }

        private async Task<List<PlayerEntity>> GenerateTeam()
        {
            var playerEntities = await _playerRepository.GetPlayerListOrderebByDescending();
            var lobbyPlayers = new List<PlayerEntity>();

            lobbyPlayers.AddRange(playerEntities.Where(player => player.VehicleType == Vehicle.First && player.IsInGame == false).Take(3));
            lobbyPlayers.AddRange(playerEntities.Where(player => player.VehicleType == Vehicle.Second && player.IsInGame == false).Take(3));
            lobbyPlayers.AddRange(playerEntities.Where(player => player.VehicleType == Vehicle.Third && player.IsInGame == false).Take(3));

            await UpdatePlayerStatus(lobbyPlayers);

            return lobbyPlayers;
        }

        private async Task UpdatePlayerStatus(List<PlayerEntity> players)
        {
            foreach (var player in players)
            {
                var entity = await _playerRepository.GetByIdAsync(player.Id);
                entity.IsInGame = !entity.IsInGame;

                await _playerRepository.UpdateAsync(entity);
            }
        }
    }
}
