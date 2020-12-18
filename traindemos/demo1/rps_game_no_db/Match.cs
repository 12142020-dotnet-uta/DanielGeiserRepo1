using System;
using System.Collections.Generic;

namespace rps_game_no_db
{
    class Match
    {
        private Guid MatchId = new Guid();
        public Guid matchId {get{return matchId;}}
        public Player Player1 { get; set;}
        public Player Player2 { get; set;}
        public int ties { get; set;}
        List<Round> Rounds = new List<Round>();

        private int p1Roundwins {get; set;}
        private int p2Roundwins {get; set;}
        /// <summary>
        /// this is the description of the method called RoundWinner
        /// this method takes an optional Player oject as a default
        /// </summary>
        /// <param name="p"></param>

        public void RoundWin(Player p = null)
        {
            if(p.PlayerId == Player1.PlayerId)
            {
                p1Roundwins++;
            }
            else if(p.PlayerId == Player2.PlayerId)
            {
                p2Roundwins++;
            }
            else
            {
                ties++;
            }

        }

        public Player MatchWinner()
        {
            if(p1Roundwins==2)
            {
                return Player1;
            }
            else if(p2Roundwins==2)
            {
                return Player2;
            }
            else
            {
                return null;
            }
        }
    } 
   
}