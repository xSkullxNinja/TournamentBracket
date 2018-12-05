namespace TournamentBracket
{
    public class TournamentTeam
    {
        public string TeamName { get; set; }
        public int Seed { get; set; }

        public TournamentTeam(string teamName)
        {
            TeamName = teamName;
        }
    }
}
