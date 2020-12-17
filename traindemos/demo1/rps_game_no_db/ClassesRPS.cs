using System;
using System.Collections.Generic;
using System.Text;

namespace rps_game_no_db
{
    public class UserAccount
    {
        public string userName {get;set;}
        public string email {get; set;}
        public string password {get; set;}
        public int Total_games {get; set;}
        public int winning {get; set;}
        public int losing {get; set;}
        public UserAccount()
        {
        }
        public UserAccount(string user,string e_mail,string passWord)
        {
            email = e_mail;
            userName = user;
            password = passWord;
            Total_games = 0;
            winning = 0;
            losing = 0;
        }
        public override string ToString()
        {
            return $"User: {userName}\nEmail: {email}";
        }
    }
}
