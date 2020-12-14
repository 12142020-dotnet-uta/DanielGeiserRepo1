using System;

namespace RPSDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            String choice=null;
            do
            {
                Console.WriteLine("Welcome to Rock, Paper, and Scissors"+
                    "\nPlease pick an option");
                Console.WriteLine("1) Normal Game\n2) Special Game\nOr put quit");
                choice = Console.ReadLine();
                if(choice == "1"){
                   NormalGame();
                   choice = null;
                }
                else if(choice == "2"){
                   SpecialGame();
                   choice = null;
                }

                Console.WriteLine(choice);

            }
            while (choice != "quit");
            Console.WriteLine("Thank You Goodbye");
        }
        public static void SpecialGame(){
            String results = null;
            String pick=null;
            Random cpuPick = new Random();
            int cpu = cpuPick.Next(500) % 5;
            Console.WriteLine("Please pick one");
            Console.WriteLine("1) Rock \n2) Paper \n3) Scissors"
                +"\n4) Lizard\n5) Spock");
            pick = Console.ReadLine();
            switch(pick)
            {
                case "1":
                    switch(cpu)
                    {
                        case 0:
                            results = "Tie";
                            break;
                        case 1:
                            results = "Paper covers Rock\n You Lose";
                            break;
                        case 2:
                            results = "Rock crushes Scissors\n You Win";
                            break;
                        case 3:
                            results = "Rock crushes Lizard\n You Win";
                            break;
                        case 4:
                            results = "Spock vaporizes Rock\n You Lose";
                            break;
                    }
                    break;
                case "2":
                    switch(cpu)
                    {
                        case 0:
                            results = "Paper covers Rock\n You Win";
                            break;
                        case 1:
                            results = "Tie";
                            break;
                        case 2:
                            results = "Scissors cut Paper\n You Lose";
                            break;
                        case 3:
                            results = "Lizard eats Paper\n You Lose";
                            break;
                        case 4:
                            results = "Paper disproves Spock\n You Win";
                            break;
                    }
                    break;
                case "3":
                    switch(cpu)
                    {
                        case 0:
                            results = "Rock crushes Scissors\n You Lose";
                            break;
                        case 1:
                            results = "Scissors cut Paper\n You Win";
                            break;
                        case 2:
                            results = "Tie";
                            break;
                        case 3:
                            results = "Scissors decapitates Lizard\n You Win";
                            break;
                        case 4:
                            results = "Spock smashes Scissors\n You Lose";
                            break;
                    }
                    break;
                case "4":
                     switch(cpu)
                    {
                        case 0:
                            results = "Rock crushes Lizard\n You Lose";
                            break;
                        case 1:
                            results = "Lizard eats Paper\n You Win";
                            break;
                        case 2:
                            results = "Scissors decapitates Lizard\n You Lose";
                            break;
                        case 3:
                            results = "Tie";
                            break;
                        case 4:
                            results = "Lizard poisons Spock\n You Win";
                            break;
                    }
                    break;
                case "5":
                     switch(cpu)
                    {
                        case 0:
                            results = "Spock vaporizes Rock\n You Win";
                            break;
                        case 1:
                            results = "Spock smashes Scissors\n You Win";
                            break;
                        case 2:
                            results = "Paper disproves Spock\n You Lose";
                            break;
                        case 3:
                            results = "Lizard poisons Spock\n You Lose";
                            break;
                        case 4:
                            results = "Tie";
                            break;
                    }
                    break;
                
            }

            Console.WriteLine("\n"+results);
        }
        public static void NormalGame(){
            String pick=null;
            String result=null;
            Random cpuPick = new Random();
            int cpu = cpuPick.Next(300) % 3;
            Console.WriteLine("Please pick one");
            Console.WriteLine("1) Rock \n2) Paper \n3) Scissors");
            pick = Console.ReadLine();
            if(pick == "1")
            {
                if(cpu == 0)
                {
                    result="Tie";
                }
                else if(cpu == 1)
                {
                    result = "Paper covers Rock\n You Lose!";
                }
                else if(cpu == 2)
                {
                    result = "Rock crushes Scissors\nYou Win!";
                }
            }
            else if(pick == "2")
            {
                if(cpu == 0)
                {
                    result = "Paper covers Rock\n You Win!";
                }
                else if(cpu == 1)
                {
                    result="Tie";
                }
                else if(cpu == 2)
                {
                    result = "Scissors cuts paper\nYou Lose!";
                }
            }
            else if(pick == "3")
            {
                if(cpu == 0)
                {
                    result = "Rock crushes Scissors\nYou Lose!";
                }
                else if(cpu == 1)
                {
                    result = "Scissors cuts paper\nYou Win!";
                }                
                else if(cpu == 2)
                {
                    result="Tie";
                }

            }

            Console.WriteLine($"\n{result}");
        }
    }
}
