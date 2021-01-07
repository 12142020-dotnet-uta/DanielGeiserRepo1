using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace ModelLayer
{
    public class Cart
    {

        [Required]
        public Guid customer { get; set; }
        public List<Item> shoppingCart { get; set; }
        public Cart(Customer c)
        {
            customer = c.Customer_Id;
            shoppingCart = new List<Item>();

        }

        /// <summary>
        /// Adding an item to a cart
        /// </summary>
        /// <param name="item"></param>
        public void AddtoCart(Item item)
        {
            shoppingCart.Add(item);
        }
        public void CustomerGetsCart(Customer c)
        {
            customer = c.Customer_Id;
        }
        public void showCart()
        {
            foreach (var y in shoppingCart)
            {
                Console.WriteLine(y);
            }
        }

    }
}
