using System;
using System.Collections.Generic;

namespace Full_work_RPS_no_db
{
    public class main
    {
        public static List<Player> totalAccounts = new List<Player>();
        public static List<Round> rounds = new List<Round>();
        public static List<MatchResults> matches = new List<MatchResults>();
        public static Player temp;
        public static int firstStep;
        static void Main(string[] args)
        {
            totalAccounts.Add(new Player(0,"computer","antihuman","humnansbad@earth.com","010101"));
            totalAccounts.Add(new Player(1,"Dan","Mag","dragon@gmail.com","kings1234"));
            totalAccounts.Add(new Player(2,"Max","Powers","historyiswrong@yahoo.com","1234567"));
            totalAccounts.Add(new Player(3,"the","People","government@hotmail.com","2020ending"));
            int begining = 0;

            do{
                firstStep = Program.signOn();
                if(firstStep == 1)
                {
                    temp = Program.Login();
                    if(temp.Id == 999)
                    {
                        temp = Program.AutoCreatePlayer(temp);
                        Program.MatchMenu(temp);
                    }
                    else
                    {
                        Program.MatchMenu(temp);
                    }
                }
                else if(firstStep == 2)
                {
                    temp = Program.CreatePlayer();
                    totalAccounts.Add(temp);
                    Program.MatchMenu(temp);
                }
                else if(firstStep == 3)
                {
                    begining = 1;
                }

            }while(begining == 0);
            
        }
    }
}