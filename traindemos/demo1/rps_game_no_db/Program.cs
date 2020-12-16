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

                //Console.WriteLine(userResponse);
                userResp = int.TryParse(userResponse,out userConvertResponse);
                // if(userResp==false || userConvertResponse <1 && userConvertResponse>3)
                // {
                //     Console.WriteLine("Your response is invaild");
                // }
                switch(userResponse)
                {
                    case "rock":
                        userConvertResponse = 1;
                        break;
                    case "paper":
                        userConvertResponse = 2;
                        break;
                    case "scissors":
                        userConvertResponse = 3;
                        break;
                    case "Rock":
                        userConvertResponse = 1;
                        break;
                    case "Paper":
                        userConvertResponse = 2;
                        break;
                    case "Scissors":
                        userConvertResponse = 3;
                        break;
                }
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
                    Console.WriteLine("You Tied");
                    again = Playagain(null);
                }
                else{
                    if(userConvertResponse == 1 && ComputerPick == 2)
                    {
                        Console.WriteLine("Paper covers rock\nYou Lost");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 1 && ComputerPick == 3)
                    {
                        Console.WriteLine("Rock crushes Scissors\nYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 1)
                    {
                        Console.WriteLine("Paper covers Rock\nYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 3)
                    {
                        Console.WriteLine("Scissors cuts paper\nYou Lost");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 2)
                    {
                        Console.WriteLine("Scissors cuts paper\nYou Won");
                        again = Playagain(null);
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 1)
                    {
                        Console.WriteLine("Rock crushes Scissors\nYou Lost");
                        again = Playagain(null);
                    }

                }

                Console.WriteLine();
               
            }while(userResp == false || again.Equals("no") == false);
            Console.WriteLine("Thanks for playing. \nGoodbye!");

        }
        public static string Playagain(string choice){
            do{
                Console.WriteLine("Play Again?\nType yes or no");
                choice = Console.ReadLine();
                if(choice.Equals("yes")==false)
                {
                    if(choice.Equals("no")==false)
                    {
                        choice = null;
                    }
                }

            }while(choice == null);
            return choice;
        }
        
    }
}
