using System;
using System.Collections.Generic;

namespace project_0
{
    public class Customer
    {
        public int Id {get; set;}
        public string firstName {get; set;}
        public string lastName {get; set;}
        private List<Order> orderHistory;
        private Location favStore { get; set;}
    }
}