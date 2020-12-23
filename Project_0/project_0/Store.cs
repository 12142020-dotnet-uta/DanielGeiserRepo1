using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class Store
    {
        [Key]
        public int Id {get; set;}
        public string storeName {get; set;}
        public string location {get; set;}
        private Cart ShoppingCart {get; set;}
        private double TotalSales;
        public double totalSales {get; set;}
        public List<Orders> orders {get; set;}
        public List<InventoryItem> productList {get; set;}
    }
}