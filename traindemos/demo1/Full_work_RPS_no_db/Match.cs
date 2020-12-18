using System;
using System.Collections.Generic;

namespace Full_work_RPS_no_db
{
    public class Match
    {
        public int number_of_games {get; set;}
        public int playerOne {get; set;}
        public int computer {get; set;}
        private int limitMatches {get{return 3;}}
        List<Round> rounds {get; set;}


        public Match()
        {
            number_of_games = limitMatches;
            playerOne = 0;
            computer = 0;
            rounds = new List<Round>();
        }

        public void Winning(string win, string choice1, string choice2)
        {
            rounds.Add(new Round(win,choice1,choice2));
            number_of_games -= 1;
            if(win == "cpu")
            {
                computer += 1;
            }
            else if(win == "you")
            {
                playerOne += 1;
            }
            else if(win == "tie")
            {
                playerOne += 1;
                computer += 1;
            }
        }

        public bool Check()
        {
            if(playerOne == (limitMatches/2)+1)
            {
                Console.WriteLine("You have WON the game!\nResults: ");
                return true;
            }
            else if(computer == (limitMatches/2)+1)
            {
                Console.WriteLine("You have LOST the game!\nResults: ");
                return true;
            }
            else if(computer == (limitMatches/2)+1 && playerOne == (limitMatches/2)+1)
            {
                Console.WriteLine("The game was a Tie");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ListTheEntries()
        {
            foreach (var entry in rounds)
            {
                Console.Write("\t"+entry.ToString()+"\n");
            }
        }
    }
}