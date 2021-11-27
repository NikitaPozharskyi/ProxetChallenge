using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.Services.Interfaces
{
    public interface ITeamService
    {
        Task<(List<PlayerEntity>, List<PlayerEntity>)> GetTeamsToLobby();
    }
}
