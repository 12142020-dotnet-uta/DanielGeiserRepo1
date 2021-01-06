﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.ViewModels
{
    public class LoginPlayerViewModel
    {
        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "First Name")]
        public string Fname { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "The name must be from 3 to 20 characters")]
        [RegularExpression(@"[a-zA-z]+$", ErrorMessage = "Use letters only please")]
        [Required]
        [Display(Name = "Last Name")]
        [DataType(DataType.Password)]
        public string Lname { get; set; }
    }
}