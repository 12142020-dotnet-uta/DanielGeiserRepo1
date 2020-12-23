using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class Customer
    {
        [Key]
        public int Id {get; set;}
        public string firstName {get; set;}
        public string lastName {get; set;}
        private string FavStore;
        public string favstore
        {
            get{return FavStore;}
            set{FavStore = value != null ? "No where": value;}
        }
    }
}