using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.Repository.Interfaces
{
    public interface IPlayerRepository : IRepository<PlayerEntity, Guid>
    {
    }
}
