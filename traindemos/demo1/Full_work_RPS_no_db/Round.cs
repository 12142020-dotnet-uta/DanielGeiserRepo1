namespace Full_work_RPS_no_db
{
    public class Round
    {
        public int match_id {get; set;}
        public string winner {get; set;}
        public string P1picked {get; set;}
        public string P2picked {get; set;}

        public Round(int match,string win, string comPick,string plaPick)
        {
            match_id = match;
            winner = win;
            P1picked = comPick;
            P2picked = plaPick;
        }
        public override string ToString()
        {
            return $"Winner: {winner}, Computers Pick: {P1picked} Players Pick: {P2picked}";
        }
    }
}