using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProxNetChallenge.Entities;
using ProxNetChallenge.Repository.Interfaces;

namespace ProxNetChallenge.Repository
{
    public class PlayerRepository : Repository<Context,PlayerEntity, Guid>,IPlayerRepository
    {
        protected PlayerRepository(Context dbContext) : base(dbContext)
        {
        }

        public async Task<List<PlayerEntity>> GetPlayerListOrderebByDescending()
        {
            return await DbSet.OrderByDescending(entity => entity.WaitingTime).ToListAsync();
        }

    }
}
