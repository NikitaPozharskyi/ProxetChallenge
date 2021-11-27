using System;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Entities.models;

namespace ProxNetChallenge.Services.Interfaces
{
    public interface IPlayerService
    {
        Task AddPlayer(string playerName, Vehicle vehicleType);
        Task RemovePlayer(Guid id);
        Task RemovePlayer(string playerName);
        Task UpdatePlayer(PlayerEntity player);
        Task<PlayerEntity> GetPlayer(Guid id);
        Task<PlayerEntity> GetPlayer(string playerName);

        bool IsHealthy();

    }
}
