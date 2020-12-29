using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Alt_project0
{
    
    public class Cart
    {
        [Required]
        public Guid customer {get; set;}
        public List<Item> shoppingCart{get; set;}
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
        public void showCart()
        {
             foreach(var y in shoppingCart)
            {
                Console.WriteLine(y);
            }
        }
        
    }
}