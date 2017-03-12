using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracket
{
    public class TournamentBracket
    {
        public int RemainingGames { get; set; }
        public int GameCount { get; set; }
        public int TeamCount { get; set; }
        public List<TournamentTeam> Teams { get; set; }
        public List<TournamentGame> CurrentGames { get; set; }
        public List<TournamentGame> NextGames { get; set; }

        public TournamentBracket()
        {
            Teams = new List<TournamentTeam>();
        }
        public void AddTeam(TournamentTeam team)
        {
            Teams.Add(team);
            TeamCount += 1;
        }

    }
}
