namespace Full_work_RPS_no_db
{
    public class Player
    {
        public int Id {get; set;}
        public string firstName {get;set;}
        public string lastName {get; set;}
        public string email {get; set;}
        public string password {get; set;}
        public int Total_games {get; set;}
        public int won {get; set;}y
        public int lost {get; set;}
        public int tie{get; set;}
        public bool signedin {get; set;}
        public Player()
        {

        }
        public Player(int id,string first,string last,string e_mail,string passWord): this()
        {
            Id = id;
            email = e_mail;
            firstName = first;
            lastName = last;
            password = passWord;
            Total_games = 0;
            won = 0;
            lost = 0;
            tie = 0;
            
            signedin = false;
        }
        public Player(int id,string first,string last,string e_mail,string passWord,bool start): this()
        {
            Id = id;
            email = e_mail;
            firstName = first;
            lastName = last;
            password = passWord;
            Total_games = 0;
            won = 0;
            lost = 0;
            tie = 0;
            
            signedin = start;
        }

        public bool SignIn(string Fname,string Lname, string passWord)
        {
            if(password.Equals(passWord)==true && firstName.Equals(Fname)==true && lastName.Equals(Lname)==true)
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
        public void combine(int a, int b, int c, int d)
        {
            Total_games += a;
            won += b;
            lost += c;
            tie += d;
        }

        public override string ToString()
        {
            return $"User: {firstName} {lastName}\nEmail: {email}\nTotal Games: {Total_games}\nWon: {won}\nLost: {lost}\nTie: {tie}";            
        }
    }
}