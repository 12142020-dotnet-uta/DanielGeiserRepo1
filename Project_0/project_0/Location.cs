using System.Collections.Generic;

namespace project_0
{
    public class Location
    {
        public int Id {get; set;}
        public string storeName {get; set;}
        public string location {get; set;}
        public List<Product> productList {get; set;}
    }
}