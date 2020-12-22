namespace Full_work_RPS_no_db
{
    public class MatchResults
    {
        public int MatchID {get; set;}
        public int userID {get; set;}
        public string Winner {get; set;}

        public MatchResults(int a, int b , string name)
        {
            MatchID = a;
            userID = b;
            Winner = name;
        }
    }
}