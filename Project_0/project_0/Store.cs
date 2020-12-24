using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_0
{
    public class Store
    {
        [Key]
        public int? Id {get; set;}
        [Required]
        public string storeName {get; set;}
        [Required]
        public string location {get; set;}
        private Cart ShoppingCart {get; set;}
        private double TotalSales;
        public double totalSales {get; set;}
        public List<Orders> orders {get; set;}
        public List<Item> productList {get; set;}
    }
}