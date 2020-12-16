using System;


namespace rps_game_no_db
{
    class Program
    {
        static void Main(string[] args)
        {
            int userConvertResponse;
            bool userResp;
            string again  = null;
            string userResponse;
            do{
                //Console.WriteLine("Hello World!");
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
