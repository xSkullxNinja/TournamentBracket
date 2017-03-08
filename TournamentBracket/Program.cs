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
            List<string> players = new List<string>();
            for(int i = 1; i <= numPlayers; ++i)
            {
                players.Add(input.GetParticipantName(i));
            }
            Console.WriteLine(players.Count);
            for (int i = 0; i < numPlayers; ++i)
            {
                Console.WriteLine(players[i]);
            }
        }
        private void InputPlayer(string playerName)
        {

        }
    }
}
