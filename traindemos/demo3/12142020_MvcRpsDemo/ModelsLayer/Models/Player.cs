using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Player
    {
        [Key]
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        [StringLength(20,MinimumLength =3,ErrorMessage ="The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage ="Use letters only please")]
        [Required]
        [Display(Name ="First Name")]
        public string Fname { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Range(0,int.MaxValue)]
        [Display(Name ="Number of Wins")]
        public int numWins { get; set; }
        [Range(0, int.MaxValue)]
        [Display(Name = "Number of Losses")]
        public int numLosses { get; set; }
        public byte[] ByteArrayImage { get; set; }
        //public string StringImage { get; set; }



        public Player(string fname = "null", string lname = "null")
        {
            this.Fname = fname;
            this.Lname = lname;
        }


        //below is methods
        /// <summary>
        /// This method inrements the Wins or the player
        /// </summary>
        public void AddWin()
        {
            numWins++;
        }

        /// <summary>
        /// This methods increments the wins of the player by the passed integer amount.
        /// </summary>
        /// <param name="x"></param>
        public void AddWin(int x)
        {
            numWins += x;
        }

        public void AddLoss()
        {
            numLosses++;
        }

        public int[] GetWinLossRecord()
        {
            int[] winsAndLosses = new int[2]; // create an array to hole the num of wins and losses

            winsAndLosses[0] = numWins; // put in the wins and losses
            winsAndLosses[1] = numLosses;

            return winsAndLosses; // return the array.
        }
    }
 }
