using System.ComponentModel.DataAnnotations;

namespace project_0
{
    public class InventoryItem :Item
    {
        [Key]
        int StoreID {get; set;}
        public InventoryItem(int store,string name, double cost, string des, int howmany)
        {
            StoreID = store;
            productName = name;
            price = cost;
            description = des;
            qty = howmany;
            sale = 0;
        }
        
    }
}