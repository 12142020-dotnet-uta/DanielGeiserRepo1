using System;
using System.Collections.Generic;

//login, and logout
// store informaiton for history
// total games, wins, losts
//percentages of picks
// Round table, Match table, Player table

namespace rps_game_no_db
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> players = new List<Player>();   
            List<Player> matches = new List<Player>();
            List<Player> rounds = new List<Player>();

            //create the computer that everyone plays against
            Player p1 = new Player()
            {
                firstName = "Computer",
                lastName = "Skynite"
            };
            players.Add(p1);

            Match match = new Match();

            //Login in a player or creat a new player. Unique fristName and lastName,
            //other wise, grab the existing player

            Console.WriteLine("Please enter your first name.\nif you enter a unique first and last name i will create a new player");
            string useFirstName = Console.ReadLine();
            string[] splitName = useFirstName.Split(' ');
            

            Player p2 = new Player()
            {
                firstName = splitName[0],
                lastName = splitName[1]
            };
            players.Add(p2);

            //user will choose Rock, Paper, or Scissors
            int userConvertResponse;
            bool userResp;
            string again  = null;
            string userResponse;
            do{
                Console.WriteLine($"Welcome {p2.firstName} {p2.lastName}");
                Console.WriteLine("Please choose Rock, Paper, or Scissors by typing 1, 2, or 3 and hitting enter"+
                    "\n\t1) Rock\n\t2) Paper\n\t3) Scissors");
                userResponse = Console.ReadLine();
                switch(userResponse)
                {
                    case "rock":
                        userResponse = "1";
                        break;
                    case "paper":
                        userResponse = "2";
                        break;
                    case "scissors":
                        userResponse = "3";
                        break;
                    case "Rock":
                        userResponse = "1";
                        break;
                    case "Paper":
                        userResponse = "2";
                        break;
                    case "Scissors":
                        userResponse = "3";
                        break;
                }

                //Console.WriteLine(userResponse);
                userResp = int.TryParse(userResponse,out userConvertResponse);
                // if(userResp==false || userConvertResponse <1 && userConvertResponse>3)
                // {
                //     Console.WriteLine("Your response is invaild");
                // }
                
                switch(userConvertResponse)
                {
                    case int a when userConvertResponse > 3:
                        Console.WriteLine("Your response is invaild");
                        userResp = false;
                        break;

                    case int b when userConvertResponse < 1:
                        Console.WriteLine("Your response is invaild");
                        userResp = false;
                        break;
                }

                Random cpu = new Random();
                int ComputerPick= cpu.Next(100)%3 +1;
                if(userConvertResponse == ComputerPick){
                    Console.WriteLine("\n\tYou Tied");
                    again = Playagain(null);
                }
                else{
                    if(userConvertResponse == 1 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nPaper covers rock\n\tYou Lost");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 1 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nPaper covers Rock\n\tYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Lost");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Lost");
                        again = Playagain(null);
                    }

                }

                Console.WriteLine();
               
            }while(userResp == false || again.Equals("no") == false);
            Console.WriteLine("Thanks for playing. \nGoodbye!");

        }
        public static string Playagain(string choice){
            Console.WriteLine();
            do{
                Console.WriteLine("Play Again?\nType yes or no");
                choice = Console.ReadLine();
                // if(choice.Equals("yes")==false)
                // {
                //     if(choice.Equals("no")==false)
                //     {
                //         choice = null;
                //     }
                // }
                switch(choice)
                {
                    case "yes":
                        choice = "yes";
                        break;
                    case "y":
                        choice = "yes";
                        break;
                    case "no":
                        choice = "no";
                        break;
                    case "n":
                        choice = "no";
                        break;
                    default:
                        choice = null;
                        break;
                }

            }while(choice == null);
            return choice;
        }
        
    }
}
