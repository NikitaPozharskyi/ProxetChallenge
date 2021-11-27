using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Entities.models;
using ProxNetChallenge.Repository.Interfaces;

namespace ProxNetChallenge.Repository
{
    public class LobbyPlayerRepository : Repository<Context, LobbyPlayerEntity, Guid>, ILobbyPlayerRepository
    {
        public LobbyPlayerRepository(Context dbContext) : base(dbContext)
        {
        }
        private async Task<List<LobbyPlayerEntity>> GenerateTeam()
        {
            var lobbyPlayers = new List<LobbyPlayerEntity>();
            var players = await GetLobbyPlayersOrderebDyDecending();

            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.First).Take(3));
            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.Second).Take(3));
            lobbyPlayers.AddRange(players.Where(player => player.VehicleType == Vehicle.Third).Take(3));

            if (lobbyPlayers.Count < 9) return null;

            await UpdateLobbyPlayerStatus(lobbyPlayers);

            return lobbyPlayers;
        }

        public async Task<List<LobbyPlayerEntity>> GetLobbyPlayersOrderebDyDecending() => DbSet.OrderByDescending(player => player.IncomeDate).ToList();

        private async Task UpdateLobbyPlayerStatus(List<LobbyPlayerEntity> players)
        {
            foreach (var player in players)
            {
                player.IsTaken = true;
                await UpdateAsync(player);
            }
        }

        private async Task RemoveFromLobby(List<LobbyPlayerEntity> players)
        {
            foreach (var player in players)
            {
                var entity = await GetByIdAsync(player.Id);

                await DeleteAsync(entity);
            }
        }
    }
}
