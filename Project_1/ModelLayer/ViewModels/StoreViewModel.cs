using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class StoreViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
    }
}
