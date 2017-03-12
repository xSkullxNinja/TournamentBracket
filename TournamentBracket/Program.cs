using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            (new Program()).Run();
        }
        public void Run()
        {
            UserInput input = new UserInput();
            int numPlayers = input.GetNumParticipants();
            SingleEliminationBracket bracket = new SingleEliminationBracket();
            for(int i = 1; i <= numPlayers; ++i)
            {
                TournamentTeam team = new TournamentTeam(input.GetParticipantName(i));
                bracket.AddTeam(team);
            }
            bracket.BeginTournament();
            while (bracket.RemainingGames > 0)
            {
                bracket.PrintCurrentRound();
                bracket.PlayRound();
                Console.WriteLine("Remaining Games: " + bracket.RemainingGames);
            }
            Console.WriteLine("Tournament Winner: " + bracket.CurrentGames[0].FirstTeam.Name);
            //Console.WriteLine(bracket.Teams.Count);
            //for (int i = 0; i < numPlayers; ++i)
            //{
            //    Console.WriteLine(bracket.Teams[i].Name);
            //}
            //string reroll = "";
            //while (string.IsNullOrWhiteSpace(reroll))
            //{
            //    //SingleEliminationGames(players);
            //    Console.WriteLine("Reroll?");
            //    reroll = Console.ReadLine();
            //}
        }
        //private void InputPlayer(string playerName)
        //{

        //}
        //private void SingleEliminationGames(List<string> Teams)
        //{
        //    Random rand = new Random();
        //    List<string> NewTeams = new List<string>();
        //    for(int i = 0; i < Teams.Count; ++i)
        //    {
        //        NewTeams.Add(Teams[i]);
        //    }
        //    List<string> Games = new List<string>();
        //    for(int i = 0; i < Teams.Count / 2; ++i)
        //    {
        //        string nextGame = "";
        //        int firstTeam = rand.Next(0, NewTeams.Count);
        //        nextGame += NewTeams[firstTeam] + " V ";
        //        NewTeams.RemoveAt(firstTeam);
        //        int secondTeam = rand.Next(0, NewTeams.Count);
        //        nextGame += NewTeams[secondTeam];
        //        NewTeams.RemoveAt(secondTeam);
        //        Games.Add(nextGame);
        //    }
        //    Console.WriteLine("Games: " + Games.Count);
        //    for (int i = 0; i < Games.Count; ++i)
        //    {
        //        Console.WriteLine(Games[i]);
        //    }

        //}
    }
}
