using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxNetChallenge.Services.Interfaces
{
    public interface ILobbyService
    {
        Task AddPlayerToLobby(Guid id);
    }
}
