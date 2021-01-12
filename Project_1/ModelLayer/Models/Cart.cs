using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class Cart
    {
        public int id { get; set; }
        [Key]
        [Column("Location")]
        public Store store_id { get; set; }
        [Column("Owner_Id")]
        public Guid customer { get; set; }
        [Column("Cart")]
        public Item InShoppingCart { get; set; }
        
        public Cart() { }
        public Cart(Customer c)
        {
            customer = c.Customer_Id;
            //shoppingCart = new List<Item>();

        }
        
        public void CustomerGetsCart(Customer c)
        {
            customer = c.Customer_Id;
        }

        /*/// <summary>
        /// Adding an item to a cart
        /// </summary>
        /// <param name="item"></param>
        public void AddtoCart(Item item)
        {
            shoppingCart.Add(item);
        }
        
        public void showCart()
        {
            foreach (var y in shoppingCart)
            {
                Console.WriteLine(y);
            }
        }*/

    }
}
