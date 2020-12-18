using System;

namespace rps_game_no_db
{
    class Round
    {
        private Guid RoundId = new Guid();
        public Guid roundId {get{return roundId;}}
        public Choice Player1Choice {get; set;}
        public Choice Player2Choice {get; set;}
        public Player WinningPlayer {get; set;} = null;

            
    }
   
}