using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Models;
using ProxNetChallenge.Repository.Interfaces;

namespace ProxNetChallenge.Repository
{
    public class LobbyPlayerRepository : Repository<Context, LobbyPlayerEntity, Guid>, ILobbyPlayerRepository 
    {
        protected LobbyPlayerRepository(Context dbContext) : base(dbContext)
        {
        }
        private async Task<List<LobbyPlayerEntity>> GenerateTeam()
        {
            var lobbyPlayers = new List<LobbyPlayerEntity>();

            lobbyPlayers.AddRange(DbSet.Where(player => player.VehicleType == Vehicle.First).Take(3));
            lobbyPlayers.AddRange(DbSet.Where(player => player.VehicleType == Vehicle.Second).Take(3));
            lobbyPlayers.AddRange(DbSet.Where(player => player.VehicleType == Vehicle.Third).Take(3));

            await RemoveFromLobby(lobbyPlayers);

            return lobbyPlayers;
        }

        private async Task RemoveFromLobby(List<LobbyPlayerEntity> players)
        {
            foreach (var player in players)
            {
                var entity = await GetByIdAsync(player.Id);

                await DeleteAsync(entity);
            }
        }

        public async Task<(List<LobbyPlayerEntity>, List<LobbyPlayerEntity>)> GetTeams()
        {
            var firstTeam = await GenerateTeam();
            var secondTeam = await GenerateTeam();
        }
    }
}
