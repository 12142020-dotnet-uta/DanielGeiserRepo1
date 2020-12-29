using System.ComponentModel.DataAnnotations;

namespace Alt_project0
{
    public class Item 
    {
        public int? Id {get; set;}
        [Required]
        private int Qty;
        private double Sale;
        [Required]
        public int productId {get; set;}

        public int qty
        {
            get{return Qty;}
            set{Qty = value < 0 ? -value : value;}
        }
        public double sale
        {
            get{return Sale;}
            set{
                if(value < 0)
                {
                    Sale = 0;
                }
                else if(value >= 1)
                {
                    Sale = .9;
                }
                else{
                    Sale = value;
                }
            }
        }

        public Item()
        {

        }
        public Item(int storeID, int qty,Product Aproduct):this()
        {
            Id = storeID;
            Qty = qty;
            productId = Aproduct.productId;
        }
    }
}