using System;
using System.Collections.Generic;
using System.Text;

namespace Full_work_RPS_no_db
{
    class Program
    {
        // public static List<Player> totalAccounts = new List<Player>();
        // public static List<Round> rounds = new List<Round>();
        // public static List<Match> matches = new List<Match>();
        // public static Player temp;
        // public static int firstStep;
        public static string userFN;
        public static string userLN;
        public static string PW;
        // static void Main(string[] args)
        // {
        //     totalAccounts.Add(new Player(0,"computer","antihuman","humnansbad@earth.com","010101"));
        //     totalAccounts.Add(new Player(1,"Dan","Mag","dragon@gmail.com","kings1234"));
        //     totalAccounts.Add(new Player(2,"Max","Powers","historyiswrong@yahoo.com","1234567"));
        //     totalAccounts.Add(new Player(3,"the","People","government@hotmail.com","2020ending"));
        //     int begining = 0;

        //     do{
        //         firstStep = signOn();
        //         if(firstStep == 1)
        //         {
        //             temp = Login();
        //             if(temp.Id == 999)
        //             {
        //                 continue;
        //             }
        //             else
        //             {
        //                 MatchMenu();
        //             }
        //         }
        //         else if(firstStep == 2)
        //         {
        //             temp = CreatePlayer();
        //             totalAccounts.Add(temp);
        //             MatchMenu();
        //         }
        //         else if(firstStep == 3)
        //         {
        //             begining = 1;
        //         }

        //     }while(begining == 0);
            
        // }

        public static void MatchMenu(Player temp)
        {
            int active = 1;
            string pick1;
            do{
                temp = CheckLogin();
                

                Console.WriteLine();
            
                Console.WriteLine("Would you like to Play a Match");
                Console.WriteLine("of ROCK PAPER SCISSORS\n1) New Match\n2) Player stats"
                    +"\n3) Sign Out");
                pick1 = Console.ReadLine();
                if(pick1=="1")
                {
                    Player update = PlayAGame(temp);
                    int indexID = FindIndexUser(update.Id);
                    temp = main.totalAccounts[indexID];
                }
                else if( pick1 == "2")
                {
                    Console.WriteLine(temp.ToString());
                }
                else if(pick1 == "3")
                {
                    temp.SignOut();
                    active = 0;
                }
               
            }while(active == 1);
            Console.WriteLine("Thanks for playing. \nGoodbye!");

        }
        public static int FindIndexUser(int x)
        {
            int num = 0;
            for(int i = 0; i < main.totalAccounts.Count;i++)
            {
                if(main.totalAccounts[i].Id==x)
                {
                    num = i;
                }
            }
            return num;
        }

        public static Player PlayAGame(Player user)
        {
            Player computer = new Player();
            Match game= new Match();
            int userConvertResponse;
            bool userResp;
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
                    game.Winning(main.matches.Count +1,"tie",getResult(userConvertResponse),getResult(userConvertResponse));
                    user.addTie();
                    computer.addTie();
                }
                else{
                    if(userConvertResponse == 1 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nPaper covers rock\n\tYou Lost");
                        game.Winning(main.matches.Count +1,"cpu",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addLost();
                        computer.addWin();
                    }
                    else if(userConvertResponse == 1 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Won");
                        game.Winning(main.matches.Count +1,"you",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addWin();
                        computer.addLost();
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nPaper covers Rock\n\tYou Won");
                        game.Winning(main.matches.Count +1,"you",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addWin();
                        computer.addLost();
                    }
                    else if(userConvertResponse == 2 && ComputerPick == 3)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Lost");
                        game.Winning(main.matches.Count +1,"cpu",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addLost();
                        computer.addWin();
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 2)
                    {
                        Console.WriteLine("\nScissors cuts paper\n\tYou Won");
                        game.Winning(main.matches.Count +1,"you",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addWin();
                        computer.addLost();
                    }
                    else if(userConvertResponse == 3 && ComputerPick == 1)
                    {
                        Console.WriteLine("\nRock crushes Scissors\n\tYou Lost");
                        game.Winning(main.matches.Count +1,"cpu",getResult(ComputerPick),getResult(userConvertResponse));
                        user.addLost();
                        computer.addWin();
                    }

                }

                Console.WriteLine();
               
            }while(game.Check()==false);
            game.ListTheEntries();
            string result = game.Result();
            if(result == "WON")
            {
                main.matches.Add(new MatchResults(main.matches.Count + 1,user.Id, user.firstName + " " +user.lastName));
            }
            else if(result == "LOST")
            {
                main.matches.Add(new MatchResults(main.matches.Count + 1,0, computer.firstName + " " +computer.lastName));
            }
            main.totalAccounts[0].combine(computer.Total_games,computer.won,computer.lost,computer.tie);
            return user;
        }
        public static int signOn()
        {
            int numPicked = 0;
            int temp3;
            bool PickedNum;
            string selection;
            while(numPicked == 0)
            {
                Console.WriteLine("Welcome gamer!?\nLets play some Rock Paper Scissors\but first: ");
                Console.WriteLine("\t1) Player Login\n\t2) Create new Player\n\t3) Quit\nPlease on only use 1, 2,or 3.");
                selection = Console.ReadLine();
                if(selection.Length == 1)
                {
                    PickedNum = int.TryParse(selection,out temp3);
                    if(temp3 < 0)
                    {
                        numPicked = 0;
                    }
                    else if(temp3 >3)
                    {
                        numPicked = 0;
                    }
                    else
                    {
                        numPicked = temp3;
                    }
                }

            }
            return numPicked;      
        }
        public static Player CheckLogin()
        {
            Player temp2 = new Player();
            do{
                int total = 0;
                for(int x = 0; x < main.totalAccounts.Count;x++)
                {
                    if(main.totalAccounts[x].signedin == true)
                    {
                        temp2 = main.totalAccounts[x];
                    }
                    else
                    {
                        total++;
                    }
                }
                if(total == main.totalAccounts.Count)
                {
                    temp2.signedin = true;
                }
            }while(temp2.signedin == false);
            return temp2;
        }
        public static Player Login()
        {
            Player temp2 = new Player();
            do{
                int total = 0;
                Console.WriteLine("\nLogin with");
                Console.WriteLine("First Name: ");
                userFN = Console.ReadLine();
                Console.WriteLine("Last Name: ");
                userLN = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                PW = Console.ReadLine();
                for(int z = 0; z < main.totalAccounts.Count; z++)
                {
                    if(main.totalAccounts[z].SignIn(userFN,userLN,PW))
                    {
                        temp2 = main.totalAccounts[z];
                    }
                    else{
                        total++;
                    }
                    
                }
                if(main.totalAccounts.Count==total)
                {
                    Console.WriteLine("Nothing matched");
                    temp2.signedin = true;
                    temp2.Id = 999;
                    temp2.firstName = userFN;
                    temp2.lastName = userLN;
                    temp2.password = PW;
                }
            }while(temp2.signedin == false);

            return temp2;
        }
        public static Player AutoCreatePlayer(Player a)
        {
            a.Id = main.totalAccounts.Count + 1;
            main.totalAccounts.Add(a);
            return a;
        }

        public static Player CreatePlayer()
        {
            string first;
            string last;
            string email;
            string passW;
            string temp = "";
            while(temp == "")
            {
                Console.WriteLine("First Name: ");
                temp = vaildEntry(Console.ReadLine());
            }
            first = temp;
            temp = "";
            
            while(temp == "")
            {
                Console.WriteLine("Last Name: ");
                temp = vaildEntry(Console.ReadLine());
            }
            last = temp;
            temp = "";
            while(temp == "")
            {
                Console.WriteLine("email: ");
                temp = vaildEntry(Console.ReadLine());
            }
            email = temp;
            temp = "";
            while(temp == "")
            {
                Console.WriteLine("Enter password: ");
                temp = vaildEntry(Console.ReadLine());
            }
            passW = temp;
            temp = "";
            return new Player(main.totalAccounts.Count +1, first,last,email,passW,true);
        }

        public static string vaildEntry(string temp)
        {
            string[] words = temp.Split(' ');
            if(words.Length >= 1 && words[0] != "")
            {
                temp = words[0];
            }
            else{
                temp ="";
            }
            return temp;
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
