using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournamentBracket
{
    public class UserInput
    {
        public int GetNumParticipants()
        {
            Console.WriteLine("How many participants?");
            string numPlayersText = Console.ReadLine();
            int numPlayers = -1;
            Int32.TryParse(numPlayersText, out numPlayers);
            while (numPlayers < 1 || numPlayers > 128)
            {
                Console.WriteLine("Please enter a valid number?");
                numPlayersText = Console.ReadLine();
                Int32.TryParse(numPlayersText, out numPlayers);
            }
            return numPlayers;
        }
        public string GetParticipantName(int participantNumber)
        {
            Console.WriteLine("Please enter participant #" + participantNumber + "'s name?");
            string participantName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(participantName))
            {
                Console.WriteLine("Please enter a valid name?");
                participantName = Console.ReadLine();
            }
            return participantName;
        }
    }
}
