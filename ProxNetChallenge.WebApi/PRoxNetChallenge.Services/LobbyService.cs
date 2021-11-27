using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Repository.Interfaces;
using ProxNetChallenge.Services.Interfaces;

namespace ProxNetChallenge.Services
{
    public class LobbyService :ILobbyService
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
    }
}
