using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
    public class PlayerViewModel
    {
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        public string Lname { get; set; }
        [Range(0, int.MaxValue)]
        [Display(Name = "Number of Wins")]
        public int numWins { get; set; }
        [Range(0, int.MaxValue)]
        [Display(Name = "Number of Losses")]
        public int numLosses { get; set; }
        public string JpgStringImage { get; set; }
        public IFormFile IformFileImage { get; set; }

    }
}
