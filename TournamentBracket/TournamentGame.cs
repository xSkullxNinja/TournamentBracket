namespace TournamentBracket
{
    public class TournamentGame
    {
        public TournamentTeam FirstTeam { get; set; }
        public TournamentTeam SecondTeam { get; set; }

        public TournamentGame()
        {
            FirstTeam = null;
            SecondTeam = null;
        }

        public void AddTeam(TournamentTeam team)
        {
            if (FirstTeam == null)
            {
                FirstTeam = team;
            }
            else if (SecondTeam == null)
            {
                SecondTeam = team;
            }
        }

        public string Versus()
        {
            return FirstTeam.TeamName + " Vs " + SecondTeam.TeamName;
        }
    }
}