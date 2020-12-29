using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;


namespace project_0
{
    public class StoreAppRepsitoryLayer
    {
        static StoreAppContext SA_DbContext = new StoreAppContext();
        DbSet<Store> stores = SA_DbContext.stores;
        DbSet<Orders> orders = SA_DbContext.orders;
        DbSet<OrderedItem> orderedItems = SA_DbContext.orderedItems;
        DbSet<Item> items = SA_DbContext.ItemsAtStore;
        DbSet<Customer> customers = SA_DbContext.customers;
        DbSet<Product> products = SA_DbContext.products;

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
        public void ProcessOrder(Orders order,List<OrderedItem> list)
        {
            int OrderID = orders.Count()+1;
            orders.Add(order);
            foreach(var entry in list)
            {
                entry.OrderID = OrderID;
                orderedItems.Add(entry);
            }
            SA_DbContext.SaveChanges();
        }

        public Store SelectTheStore(int id)
        {
            Store select = new Store();
            select = stores.Where(x => x.Id == id).FirstOrDefault();
            return select;
        }

        public List<Orders> GetAllPastOrders(Customer c)
        {
            List<Orders> allorders = new List<Orders>();

            var listallorders = from o in orders
                                where o.customer.Customer_Id == c.Customer_Id
                                select o;
            foreach(var q in listallorders)
            {
                allorders.Add(q);
            }
            return allorders;
        }
        /// <summary>
        /// Using a join to combine two tables. It returns a tuple of (int, string, double, int)
        /// and the values are (productID, productName, product_Price, qty)
        /// </summary>
        /// <param name="id"></param>
        public List<(int,string,double,int)> GetItemForStore(int id)
        {
            var itemandproduct = from i in items join p in products on i.productId equals p.productId
                                where i.Id_TO_S == id
                                select new {PId = i.productId,Product = p.productName,Price = p.price , Qty = i.qty}; 
            List<(int,string,double,int)> temp = new List<(int,string,double,int)>();
            foreach(var entry in itemandproduct)
            {
                temp.Add((entry.PId,entry.Product,entry.Price,entry.Qty));
            }
            return temp;
        }
        public Product GetProduct(int id)
        {
            Product p =  products.Where(x => x.productId == id).FirstOrDefault();
            return p;
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