using System;
using System.Collections.Generic;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.ProjectModels
{
    public class Teams
    {
        public List<PlayerEntity> FirstTeam { get; set; }
        public List<PlayerEntity> SecondTeam { get; set; }
    }
}
