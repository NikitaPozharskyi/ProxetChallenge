using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Entities.models;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.Services
{
    public class LobbyService : ILobbyService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly ILobbyPlayerRepository _lobbyPlayerRepository;

        public LobbyService(IPlayerRepository playerRepository, ILobbyPlayerRepository lobbyPlayerRepository)
        {
            _playerRepository = playerRepository;
            _lobbyPlayerRepository = lobbyPlayerRepository;
        }

        public async Task AddPlayerToLobby(Guid id)
        {
            var entity = await _playerRepository.GetByIdAsync(id);
            if (entity == null)
            {
                throw new InvalidDataException("No user in base");
            }

            await _lobbyPlayerRepository.AddAsync(new LobbyPlayerEntity
            {
                PlayerId = entity.Id,
                VehicleType = entity.VehicleType,
                IncomeDate = DateTime.Now
            });
        }

        public async Task RemovePlayerFromLobby(Guid id)
        {
            var entity = await _lobbyPlayerRepository.GetByIdAsync(id);
            await _lobbyPlayerRepository.DeleteAsync(entity);
        }

        public async Task RemovePlayerFromLobby(string name)
        {
            var entity = await _playerRepository.Find(player => player.PlayerName == name);
            var lobbyPlayerEntity = await _lobbyPlayerRepository.GetByIdAsync(entity.Id);
            await _lobbyPlayerRepository.DeleteAsync(lobbyPlayerEntity);
        }

        public async Task<(List<LobbyPlayerEntity>, List<LobbyPlayerEntity>)> GenerateTeams()
        {
            var firstTeam = await GenerateTeam();
            var secondTeam = await GenerateTeam();

            if (firstTeam == null || secondTeam == null)
                return (new List<LobbyPlayerEntity>(), new List<LobbyPlayerEntity>());

            await RemoveFromLobby(firstTeam);
            await RemoveFromLobby(secondTeam);

            return (firstTeam, secondTeam);
        }
        private async Task<List<LobbyPlayerEntity>> GenerateTeam()
        {
            var lobbyPlayers = new List<LobbyPlayerEntity>();
            var players = await _lobbyPlayerRepository.GetLobbyPlayersOrderebDyDecending();

            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.First && player.IsTaken == false).Take(3));
            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.Second && player.IsTaken == false).Take(3));
            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.Third && player.IsTaken == false).Take(3));

            if (lobbyPlayers.Count < 9) return null;

            await UpdateLobbyPlayerStatus(lobbyPlayers);

            return lobbyPlayers;
        }
        private async Task UpdateLobbyPlayerStatus(List<LobbyPlayerEntity> players)
        {
            foreach (var player in players)
            {
                player.IsTaken = true;
                await _lobbyPlayerRepository.UpdateAsync(player);
            }
        }

        private async Task RemoveFromLobby(List<LobbyPlayerEntity> players)
        {
            foreach (var player in players)
            {
                var entity = await _lobbyPlayerRepository.GetByIdAsync(player.Id);

                await _lobbyPlayerRepository.DeleteAsync(entity);
            }
        }

        public async Task<List<PlayerEntity>> MapPlayers(List<LobbyPlayerEntity> players)
        {
            var playersEntityList = new List<PlayerEntity>();
            foreach (var lobbyPlayerEntity in players)
            {
                var player = await _playerRepository.GetByIdAsync(lobbyPlayerEntity.PlayerId);
                playersEntityList.Add(player);
            }

            return playersEntityList;
        }
    }
}
