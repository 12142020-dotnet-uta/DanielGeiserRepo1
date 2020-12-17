using System;
using System.Collections.Generic;
using System.Text;

namespace Full_work_RPS_no_db
{
    class Program
    {
        public static List<UserAccount> totalAccounts = new List<UserAccount>();
        public static UserAccount temp;
        public static string user;
        public static string PW;
        static void Main(string[] args)
        {
            totalAccounts.Add(new UserAccount(1,"Dark_dragon","dragon@gmail.com","kings1234"));
            totalAccounts.Add(new UserAccount(2,"white_knight","historyiswrong@yahoo.com","1234567"));
            totalAccounts.Add(new UserAccount(3,"the_people","government@hotmail.com","2020ending"));
            int active = 1;
            string pick1;
            do{
                temp = signOn();

                Console.WriteLine();
            
                Console.WriteLine("Would you like to Play a game");
                Console.WriteLine("of ROCK PAPER SCISSORS\n1) New Game\n2) User states"
                    +"\n3) Sign Out\n4) Quit");
                pick1 = Console.ReadLine();
                if(pick1=="1")
                {
                    UserAccount update = PlayAGame(temp);
                    int indexID = FindIndexUser(update.Id);
                    totalAccounts[indexID].combine(update.Total_games,update.won,update.lost);
                    temp = totalAccounts[indexID];
                }
                else if( pick1 == "2")
                {
                    Console.WriteLine(temp.ToString());
                }
                else if(pick1 == "3")
                {
                    temp.SignOut();
                }
                else if(pick1=="4")
                {
                    active = 0;
                }    
               
            }while(active == 1);
            Console.WriteLine("Thanks for playing. \nGoodbye!");
        }
        public static int FindIndexUser(int x)
        {
            int num = 0;
            for(int i = 0; i < totalAccounts.Count;i++)
            {
                if(totalAccounts[i].Id==x)
                {
                    num = i;
                }
            }
            return num;
        }

        public static UserAccount PlayAGame(UserAccount user)
        {
            Game game= new Game();
            int userConvertResponse;
            bool userResp;
            string again  = null;
            string userResponse;
            do{
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
                userResp = int.TryParse(userResponse,out userConvertResponse);
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
                    again = "yes";
                    game.Winning("tie",getResult(userConvertResponse));
                    user.addTie();
                }
                else{
                    if(userConvertResponse == 1 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nPaper covers rock\n\tYou Lost");
                        again = "yes";
                        game.Winning("cpu",getResult(ComputerPick));
                        user.addLost();
                    }
                    else if(userConvertResponse == 1 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Won");
                        again = "yes";
                        game.Winning("you",getResult(userConvertResponse));
                        user.addWin();
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nPaper covers Rock\n\tYou Won");
                        again = "yes";
                        game.Winning("you",getResult(userConvertResponse));
                        user.addWin();
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Lost");
                        again = "yes";
                        game.Winning("cpu",getResult(ComputerPick));
                        user.addLost();
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Won");
                        again = "yes";
                        game.Winning("you",getResult(userConvertResponse));
                        user.addWin();
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Lost");
                        again = "yes";
                        game.Winning("cpu",getResult(ComputerPick));
                        user.addLost();
                    }

                }

                Console.WriteLine();
               
            }while(game.Check()==false);
            game.ListTheEntries();
            return user;
        }

        public static UserAccount signOn()
        {
            UserAccount temp2 = new UserAccount();
            Console.WriteLine(totalAccounts.Count);
            do{
                int total = 0;
                for(int x = 0; x < totalAccounts.Count;x++)
                {
                    if(totalAccounts[x].signedin == true)
                    {
                        temp2 = totalAccounts[x];
                    }
                    else
                    {
                        total++;
                    }
                }
                if(totalAccounts.Count==total)
                {
                    total = 0;
                    Console.WriteLine("No one is signed in\nPlease sign in");
                    Console.WriteLine("Username: ");
                    user = Console.ReadLine();
                    Console.WriteLine("Enter password: ");
                    PW = Console.ReadLine();
                    for(int z = 0; z < totalAccounts.Count; z++)
                    {
                        if(totalAccounts[z].SignIn(user,PW))
                        {
                            temp2 = totalAccounts[z];
                        }
                        else{
                            total++;
                        }
                        
                    }
                    if(totalAccounts.Count==total)
                    {
                        Console.WriteLine("Nothing matched");
                    }
                    
                }

            }while(temp2.signedin == false);

            return temp2;
        }

        public static string getResult(int a)
        {
            string str = null;
            switch(a)
                {
                    case 1:
                        str = "Rock";
                        break;
                    case 2:
                        str = "Paper";
                        break;
                    case 3:
                        str = "Scissors";
                        break;
                }
            return str;   
        }
    }
}
