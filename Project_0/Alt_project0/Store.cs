using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alt_project0
{
    public class Store
    {
        public int? Id {get; set;}
        [Required]
        public string storeName {get; set;}
        [Required]
        public string location {get; set;}
        public double totalSales {get; set;}
        public Store()
        {

        }
        public Store(string sname,string loca)
        {
            storeName = sname;
            location = loca;
        }
        public void AddtoCart(Item i)
        {

        }
        public void CustomerGetsCart(Customer c)
        {

        }
        public void showCart()
        {
            
        }

        public override string ToString()
        {
            return $"Store number: {Id} {storeName} located in {location}";
        }

        
    }
}