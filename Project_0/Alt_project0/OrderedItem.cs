using System.ComponentModel.DataAnnotations;

namespace Alt_project0
{
    public class OrderedItem 
    {
        public int id {get; set;}
        public int? OrderID {get; set;}
        
        public string ProductName {get; set;}

        public int qtyOrdered {get; set;}

        public double pricePaid {get; set;}
        
    }
}