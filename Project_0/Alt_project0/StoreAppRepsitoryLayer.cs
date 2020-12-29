using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;


namespace Alt_project0
{
    public class StoreAppRepsitoryLayer
    {
        static StoreAppContext SA_DbContext = new StoreAppContext();
        DbSet<Store> stores = SA_DbContext.stores;
        DbSet<Orders> orders = SA_DbContext.orders;
        DbSet<OrderedItem> orderedItems = SA_DbContext.orderedItems;
        DbSet<Item> items = SA_DbContext.ItemsAtStore;
        DbSet<Customer> customers = SA_DbContext.customers;

        /// <summary>
        /// Creates a Customer after verifying that Customer does not already
        /// exist. defalult have been set. Returns Customer object.
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <returns></returns>
        public Customer CreateCustomer(string fName = "null", string lName = "null")
        {
            Customer c1 = new Customer();
            c1 = customers.Where(x => x.firstName == fName && x.lastName == lName).FirstOrDefault();

            if(c1 == null)
            {
                c1 = new Customer()
                {
                    firstName = fName,
                    lastName = lName
                };
                customers.Add(c1);
                SA_DbContext.SaveChanges();
            }
            return c1;
        }

        public Store SelectTheStore(int id)
        {
            Store select = new Store();
            select = stores.Where(x => x.Id == id).FirstOrDefault();
            return select;
        }

        public List<Item> GetItemForStore(int id)
        {
            List<Item> temp = GetItems();
            List<Item> temp2 = new List<Item>();
            foreach(var entry in temp)
            {
                if(entry.Id == id)
                {
                    temp2.Add(entry);
                }
            }
            return temp2;
        }

        public List<Item> GetItems()
        {
            
            return items.ToList();
        }

        public List<Store> GetStores()
        {
            return stores.ToList();
        }

    }
}