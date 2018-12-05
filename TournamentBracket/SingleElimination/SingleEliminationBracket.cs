using System;
using System.Collections.Generic;

namespace TournamentBracket.SingleElimination
{
    public class SingleEliminationBracket : TournamentBracket
    {
        public void BeginTournament()
        {
            SetupFirstRound();
        }
        public void SetupFirstRound()
        {
            NextGames = new List<TournamentGame>();
            var powerOfTwo = (TeamCount & (TeamCount - 1)) == 0;
            if (powerOfTwo)
            {
                for (int i = 0; i < TeamCount / 2; ++i)
                {
                    NextGames.Add(new TournamentGame());
                }
                for (int i = 0; i < TeamCount; ++i)
                {
                    NextGames[i / 2].AddTeam(Teams[i]);
                }
                GameCount = TeamCount - 1;
                RemainingGames = GameCount;
                BeginNextRound();
            }
            else
            {
                var nextPowerOfTwo = 1;
                for (var i = TeamCount; i != 1; i = i >> 1)
                {
                    nextPowerOfTwo = nextPowerOfTwo << 1;
                }
                var extraCompatants = TeamCount - nextPowerOfTwo;
                for (var i = 0; i < extraCompatants; ++i)
                {
                    NextGames.Add(new TournamentGame());
                }
                for(var i = 0; i < extraCompatants * 2; ++i)
                {
                    NextGames[i / 2].AddTeam(Teams[i]);
                }
                CurrentGames = NextGames;
                NextGames = new List<TournamentGame>();
                for (var i = 0; i < nextPowerOfTwo / 2; ++i)
                {
                    NextGames.Add(new TournamentGame());
                }
                var startingPos = extraCompatants * 2;
                for (var i = startingPos; i < TeamCount; ++i)
                {
                    NextGames[(i - extraCompatants) / 2].AddTeam(Teams[i]);
                }
                GameCount = TeamCount - 1;
                RemainingGames = GameCount;
            }
        }
        public void BeginNextRound()
        {
            CurrentGames = NextGames;
            NextGames = new List<TournamentGame>();
            for (var i = 0; i < CurrentGames.Count / 2; ++i)
            {
                NextGames.Add(new TournamentGame());
            }
            if(CurrentGames.Count == 1)
            {
                NextGames.Add(new TournamentGame());
            }
        }
        public void PlayRound()
        {
            for (var i = 0; i < CurrentGames.Count; ++i)
            {
                Console.WriteLine(CurrentGames[i].Versus());
                var winner = -1;
                while (winner < 1 || winner > 2)
                {
                    Console.WriteLine("Winner: ");
                    Console.WriteLine("1: " + CurrentGames[i].FirstTeam.TeamName);
                    Console.WriteLine("2: " + CurrentGames[i].SecondTeam.TeamName);
                    var winnerText = Console.ReadLine();
                    int.TryParse(winnerText, out winner);
                }
                if (winner == 1)
                {
                    NextGames[i / 2].AddTeam(CurrentGames[i].FirstTeam);
                }
                else
                {
                    NextGames[i / 2].AddTeam(CurrentGames[i].SecondTeam);
                }
                RemainingGames -= 1;
            }
            BeginNextRound();
        }
        public void PrintCurrentRound()
        {
            Console.WriteLine("CurrentRound");
            for (var i = 0; i < CurrentGames.Count; ++i)
            {
                Console.WriteLine(CurrentGames[i].Versus());
            }
        }
    }
}
