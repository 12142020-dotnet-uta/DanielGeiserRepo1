using System;

namespace rps_game_no_db
{
    class Player
    {
        private Guid playerId = new Guid ();
        public Guid PlayerId 
        {
            get
            {
                return PlayerId;
            } 
        }
        public string firstName 
        {
            get{return firstName;} 
            set
            {
                if(value is string && value.Length <20 && value.Length >0)
                {
                    firstName = value;
                }
                else
                {
                    throw new Exception("The first name you sent is invaild");
                }
            }
        }
        public string lastName
        {
            get{return lastName;} 
            set
            {
                if(value is string && value.Length <20 && value.Length >0)
                {
                    lastName = value;
                }
                else
                {
                    throw new Exception("The last name you sent is invaild");
                }
            }
        }
        private int numWins;
        private int numLosses;
        //default parameters given just in case nothing is placed in the method
        public Player(string fName ="", string lName = "" )
        {
            this.firstName = fName;
            this.lastName = lName;
        }

        public void AddLoss()
        {
            numLosses++;
        }

        public void AddWin()
        {
            numWins++;
        }

        public int[] GetWinLossRecord()
        {
            int[] winsAndLosses = new int[2];

            winsAndLosses[0] = numWins;
            winsAndLosses[1] = numLosses;

            return winsAndLosses;
        }

    }
   
}