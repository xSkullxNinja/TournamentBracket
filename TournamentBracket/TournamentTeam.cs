using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracket
{
    public class TournamentTeam
    {
        public string Name { get; set; }
        public int Seed { get; set; }

        public TournamentTeam(string TeamName)
        {
            Name = TeamName;
        }
    }
}
