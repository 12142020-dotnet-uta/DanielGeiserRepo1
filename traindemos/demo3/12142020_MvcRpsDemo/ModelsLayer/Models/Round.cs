using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ModelLayer
{
    public class Round
    {
        [Key]
        public Guid RoundId { get; set; }= Guid.NewGuid();
        public Choice Player1Choice { get; set; } // always the computer
        public Choice Player2Choice { get; set; } // always the user
        public Player WinningPlayer { get; set; } = new Player()
        {
            Fname = "TieGame",
            Lname = "TieGame"
        };
    }
}
