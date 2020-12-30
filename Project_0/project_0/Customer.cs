using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class Customer
    {
        [Key]
        public Guid Customer_Id {get; set;} = new Guid();
        [Required,MinLength(2)]
        public string firstName {get; set;}
        [Required,MinLength(2)]
        public string lastName {get; set;}
        private string FavStore;
        public string favstore
        {
            get{return FavStore;}
            set{FavStore = value != null ? "No where": value;}
        }
        public Customer()
        {
            
        }
        public Customer(string fname, string lname)
        {
            firstName = fname;
            lastName = lname;
        }
        public override string ToString()
        {
            return $"{firstName}  {lastName}";
        }
    }
}