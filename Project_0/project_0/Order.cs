using System.Collections.Generic;

namespace project_0
{
    public class Order
    {
        public int orderNumber {get; set;}
        public string stroeLocation {get ; set;}
        public Customer customer {get; set;}
        public List<Product> listofProducts;
    }
}