using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<LobbyPlayerEntity>> GetLobbyPlayersOrderebDyDecending() => await DbSet.OrderByDescending(player => player.IncomeDate).ToListAsync();

        
    }
}
