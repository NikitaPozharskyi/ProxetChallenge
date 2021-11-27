using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Entities.models;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.Services
{
    public class PlayerService : IPlayerService
    {

        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddPlayer(string playerName, Vehicle vehicleType)
        {
            await _playerRepository.AddAsync(new PlayerEntity
            {
                PlayerName = playerName,
                VehicleType = vehicleType
            });
        }

        public async Task RemovePlayer(Guid id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            await _playerRepository.DeleteAsync(player);
        }

        public async Task RemovePlayer(string playerName)
        {
            var player = await _playerRepository.Find(playerEntity => playerEntity.PlayerName == playerName);
            await _playerRepository.DeleteAsync(player);
        }

        public async Task UpdatePlayer(PlayerEntity player)
        {
            await _playerRepository.UpdateAsync(player);
        }

        public async Task<PlayerEntity> GetPlayer(Guid id)
        {
            return await _playerRepository.GetByIdAsync(id);
        }

        public async Task<PlayerEntity> GetPlayer(string playerName)
        {
            return await _playerRepository.Find(player => player.PlayerName == playerName);
        }
    }
}
