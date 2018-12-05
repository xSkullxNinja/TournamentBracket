using System;

namespace TournamentBracket
{
    public class UserInput
    {
        public int GetNumParticipants()
        {
            Console.WriteLine("How many participants?");
            var numPlayersText = Console.ReadLine();
            var numPlayers = -1;
            int.TryParse(numPlayersText, out numPlayers);
            while (numPlayers < 1 || numPlayers > 128)
            {
                Console.WriteLine("Please enter a valid number?");
                numPlayersText = Console.ReadLine();
                int.TryParse(numPlayersText, out numPlayers);
            }
            return numPlayers;
        }
        public string GetParticipantName(int participantNumber)
        {
            Console.WriteLine("Please enter participant #" + participantNumber + "'s name?");
            var participantName = Console.ReadLine();
            while(string.IsNullOrWhiteSpace(participantName))
            {
                Console.WriteLine("Please enter a valid name?");
                participantName = Console.ReadLine();
            }
            return participantName;
        }
    }
}
