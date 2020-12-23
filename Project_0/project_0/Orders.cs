using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class Orders
    {
        [Key]
        public int orderID {get; set;}
        public Store stroeLocation {get ; set;}
        public Customer customer {get; set;}
        public List<OrderedItem> listofProducts;
        public double total {get; set;}
        public DateTime dateTime {get; set;}
    }
}