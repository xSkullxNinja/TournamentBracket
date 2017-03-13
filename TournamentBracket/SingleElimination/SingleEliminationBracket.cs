using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracket
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
            bool powerOfTwo = (TeamCount & (TeamCount - 1)) == 0;
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
                int nextPowerOfTwo = 1;
                for (int i = TeamCount; i != 1; i = i >> 1)
                {
                    nextPowerOfTwo = nextPowerOfTwo << 1;
                }
                int extraCompatants = TeamCount - nextPowerOfTwo;
                for (int i = 0; i < extraCompatants; ++i)
                {
                    NextGames.Add(new TournamentGame());
                }
                for(int i = 0; i < extraCompatants * 2; ++i)
                {
                    NextGames[i / 2].AddTeam(Teams[i]);
                }
                CurrentGames = NextGames;
                NextGames = new List<TournamentGame>();
                for (int i = 0; i < nextPowerOfTwo / 2; ++i)
                {
                    NextGames.Add(new TournamentGame());
                }
                int startingPos = extraCompatants * 2;
                for (int i = startingPos; i < TeamCount; ++i)
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
            for (int i = 0; i < CurrentGames.Count / 2; ++i)
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
            for (int i = 0; i < CurrentGames.Count; ++i)
            {
                Console.WriteLine(CurrentGames[i].Versus());
                int winner = -1;
                while (winner < 1 || winner > 2)
                {
                    Console.WriteLine("Winner: ");
                    Console.WriteLine("1: " + CurrentGames[i].FirstTeam.Name);
                    Console.WriteLine("2: " + CurrentGames[i].SecondTeam.Name);
                    string winnerText = Console.ReadLine();
                    Int32.TryParse(winnerText, out winner);
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
            for (int i = 0; i < CurrentGames.Count; ++i)
            {
                Console.WriteLine(CurrentGames[i].Versus());
            }
        }
    }
}
