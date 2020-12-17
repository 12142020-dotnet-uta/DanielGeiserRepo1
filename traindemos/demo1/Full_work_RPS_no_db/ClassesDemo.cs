using System;
using System.Collections.Generic;
using System.Text;

namespace Full_work_RPS_no_db
{
    public class UserAccount
    {
        public int Id {get; set;}
        public string userName {get;set;}
        public string email {get; set;}
        public string password {get; set;}
        public int Total_games {get; set;}
        public int won {get; set;}
        public int lost {get; set;}
        public int tie{get; set;}
        public bool signedin {get; set;}
        public UserAccount()
        {
        }
        public UserAccount(int id,string user,string e_mail,string passWord): this()
        {
            Id = id;
            email = e_mail;
            userName = user;
            password = passWord;
            Total_games = 0;
            won = 0;
            lost = 0;
            tie = 0;
            
            signedin = false;
        }

        public bool SignIn(string Uname, string passWord)
        {
            if(password.Equals(passWord)==true)
            {
                signedin = true;
                return true;
            }
            else{
                return false;
            }
        }
        public void SignOut()
        {
            signedin = false;
        }
        public void addTie()
        {
            tie++;
            Total_games++;
        }

        public void addWin()
        {
            won++;
            Total_games++;
        }

        public void addLost()
        {
            lost++;
            Total_games++;
        }
        public void combine(int a, int b, int c)
        {

        }

        public override string ToString()
        {
            return $"User: {userName}\nEmail: {email}\nTotal Games: {Total_games}\nWon: {won}\nLost: {lost}\nTie: {tie}";            
        }
    }

    public class Game
    {
        public int number_of_games {get; set;}
        public int playerOne {get; set;}
        public int computer {get; set;}
        List<Round> rounds {get; set;}


        public Game()
        {
            number_of_games = 5;
            playerOne = 0;
            computer = 0;
            rounds = new List<Round>();
        }

        public void Winning(string win, string choice)
        {
            rounds.Add(new Round(win,choice));
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
            if(playerOne == 3)
            {
                Console.WriteLine("You have WON the game!\nResults: ");
                return true;
            }
            else if(computer == 3)
            {
                Console.WriteLine("You have LOST the game!\nResults: ");
                return true;
            }
            else if(computer == 3 && playerOne == 3)
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

    public class Round
    {
        public string winner {get; set;}
        public string picked {get; set;}

        public Round(string win, string pick)
        {
            winner = win;
            picked = pick;
        }
        public override string ToString()
        {
            return $"Winner: {winner}, Pick: {picked}";
        }
    }
}
