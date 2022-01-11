using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.Charades
{
    public class Team
    {
        public string TeamName { get; }
        public List<Player> Players { get; }
        public Team(string teamName, List<Player> players)
        {
            TeamName = teamName;
            Players = players;
        }
    }
}
