using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.Services.Interfaces
{
    public interface ILobbyService
    {
        Task AddPlayerToLobby(Guid id);
        Task RemovePlayerFromLobby(Guid id);
        Task RemovePlayerFromLobby(string name);
        Task<(List<LobbyPlayerEntity>, List<LobbyPlayerEntity>)> GenerateTeams();
        Task<List<PlayerEntity>> MapPlayers(List<LobbyPlayerEntity> players);

    }
}
