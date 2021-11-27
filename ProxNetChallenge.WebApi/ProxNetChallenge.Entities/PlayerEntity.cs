using System;
using System.Collections.Generic;
using ProxNetChallenge.Models;

namespace ProxNetChallenge.Entities
{
    public class PlayerEntity : GenericEntity
    {
        public string PlayerName { get; set; }
        public Vehicle VehicleType { get; set; }
        public int WaitingTime { get; set; }
    }
}
