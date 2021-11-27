using System.Collections.Generic;
using ProxNetChallenge.Entities;

namespace ProxNetChallenge.WebModels
{
    public class PlayerTeamsModel
    {
        public List<PlayerEntity> FirstTeam { get; set; }
        public List<PlayerEntity> SecondTeam { get; set; }
    }
}
