using System;
using System.Collections.Generic;
using ProxNetChallenge.Entities.models;

namespace ProxNetChallenge.Entities
{
    public class PlayerEntity : GenericEntity
    {
        public string PlayerName { get; set; }
        public Vehicle VehicleType { get; set; }
    }
}
