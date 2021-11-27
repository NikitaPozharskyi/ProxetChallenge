using System;
using ProxNetChallenge.Entities.Interfaces;

namespace ProxNetChallenge.Entities
{
    public class GenericEntity : IEntity
    {
        public Guid Id { get; set; }
    }
}
