using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class OrderedItem : Item
    {
        [Key]
        int OrderID {get; set;}
        public OrderedItem(int order,string name, double cost, string des, int howmany, double promo)
        {
            OrderID = order;
            productName = name;
            price = cost;
            description = des;
            qty = howmany;
            sale = promo;
        }
    }
}