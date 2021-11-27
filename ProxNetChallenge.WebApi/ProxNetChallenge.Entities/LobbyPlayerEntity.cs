using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProxNetChallenge.Entities.Interfaces;
using ProxNetChallenge.Models;

namespace ProxNetChallenge.Entities
{
    public class LobbyPlayerEntity : GenericEntity, IEntity
    {
        public Guid PlayerId { get; set; }
        public DateTime IncomeDate { get; set; }
        public Vehicle VehicleType { get; set; }

        public bool IsTaken { get; set; } = false;
    }
}
