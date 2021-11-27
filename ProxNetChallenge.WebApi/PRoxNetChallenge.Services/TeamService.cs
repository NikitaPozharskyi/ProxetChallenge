using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.Services
{
    public class TeamService : ITeamService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILobbyPlayerRepository _lobbyPlayerRepository;

        public TeamService(IPlayerRepository playerRepository, ILobbyPlayerRepository lobbyPlayerRepository)
        {
            _playerRepository = playerRepository;
            _lobbyPlayerRepository = lobbyPlayerRepository;
        }

        public async Task<(List<PlayerEntity>, List<PlayerEntity>)> GetTeamsToLobby()
        {
            var (firstTeam, secondTeam) = await _lobbyPlayerRepository.GetTeams();
            var firstTeamMapped = await MapPlayers(firstTeam);
            var secondTeamMapped = await MapPlayers(firstTeam);

            return (firstTeamMapped, secondTeamMapped);
        }

        private async Task<List<PlayerEntity>> MapPlayers(List<LobbyPlayerEntity> lobbyPlayers)
        {
            var playerEntityList = new List<PlayerEntity>();
            foreach (var lbPlayer in lobbyPlayers)
            {
                var player = await _playerRepository.Find(player => player.Id == lbPlayer.PlayerId);
                playerEntityList.Add(new PlayerEntity
                {
                    PlayerName = player.PlayerName,
                    Id = lbPlayer.PlayerId,
                    VehicleType = lbPlayer.VehicleType
                });
            }

            return playerEntityList;
        }
    }
}
