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
            Console.WriteLine("NumPlayers");
            int numPlayers = GetNumPlayers();
            Console.WriteLine("NumPlayers: " + numPlayers);
            List<string> players = new List<string>();
            for(int i = 1; i <= numPlayers; ++i)
            {
                Console.WriteLine("Player " + (i) + ": ");
                players.Add(GetPlayerName());
            }
            Console.WriteLine(players.Count);
            for (int i = 0; i < numPlayers; ++i)
            {
                Console.WriteLine(players[i]);
            }
        }
        private int GetNumPlayers()
        {
            string numPlayers = Console.ReadLine();
            return Int32.Parse(numPlayers);
        }
        private string GetPlayerName()
        {
            return Console.ReadLine();
        }
        private void InputPlayer(string playerName)
        {

        }
    }
}
