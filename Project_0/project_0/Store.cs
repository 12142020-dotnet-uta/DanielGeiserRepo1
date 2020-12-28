using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_0
{
    public class Store
    {
        [Key]
        public int Id {get; set;}
        [Required]
        public string storeName {get; set;}
        [Required]
        public string location {get; set;}
        private double TotalSales;
        private Cart ShoppingCart {get; set;}
        public double totalSales {get; set;}
        public List<Orders> orders {get; set;}
        public List<Item> ItemList {get; set;}
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