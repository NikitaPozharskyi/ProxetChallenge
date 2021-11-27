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
        public PlayerRepository(Context dbContext) : base(dbContext)
        {
        }

        public bool IsHealthy()
        {
            return DbSet != null;
        }
    }
}
