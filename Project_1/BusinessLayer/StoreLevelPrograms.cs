using Microsoft.AspNetCore.Authentication.Cookies;
using ModelLayer;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer
{
    public class StoreLevelPrograms
    {
        private readonly StoreAppRepsitoryLayer _storeAppRepsitoryLayer;
        private readonly MapperClass _mapperClass;
        public StoreLevelPrograms() { }
        public StoreLevelPrograms(StoreAppRepsitoryLayer storeAppRepsitory,MapperClass mapper)
        {
            this._storeAppRepsitoryLayer = storeAppRepsitory;
            this._mapperClass = mapper;
        }

        public static Item ProductSelection(StoreAppRepsitoryLayer context, Store store)
        {
            List<(int, string, double, int)> list = context.GetItemForStore((int)store.Id);
            Item tempItem = new Item();
            tempItem.Id_TO_S = (int)store.Id;
            int pick = 0;
            int quantity = 0;
            int counter = 1;
            int Checkqty;

            do
            {
                foreach (var entry in list)
                {
                    Console.WriteLine(counter + ") " + $"{entry.Item2} at {entry.Item3} avilable qty: {entry.Item4}");
                    counter++;
                }
                Console.WriteLine("\nWhich Product would you like to get?");
                pick = 0;//Program.menus.VaildateInput(Console.ReadLine(), list.Count);
                tempItem.productId = list[pick - 1].Item1;
                tempItem.qty = list[pick - 1].Item4;
                Console.WriteLine("\nHow many of {0} would you like? Max is {1}", list[pick - 1].Item2, list[pick - 1].Item4);
                quantity = 1;// Program.menus.VaildateInput(Console.ReadLine(), list[pick - 1].Item4);
                Checkqty = context.TooManyGrabed(tempItem, quantity);
                tempItem.qty = Checkqty;
            } while (tempItem == null);

            return tempItem;
        }

        public static void CheckOutCounter(StoreAppRepsitoryLayer context, Store store, Customer customer, List<Item> loaded)
        {
            Product temp = new Product();
            Orders order = new Orders();
            order.stroeLocation = store;
            order.customer = customer;
            List<OrderedItem> list = new List<OrderedItem>();
            double tempTotal = 0;
            foreach (var grab in loaded)
            {
                temp = context.GetProduct(grab.productId);
                OrderedItem orderedItem = new OrderedItem();
                orderedItem.ProductName = temp.productName;
                orderedItem.qtyOrdered = grab.qty;
                orderedItem.pricePaid = temp.price;
                list.Add(orderedItem);
                tempTotal = tempTotal + (grab.qty * temp.price);
            }
            Console.WriteLine("Current Total: {0:0.00}", tempTotal);
            order.total = tempTotal;
            order.dateTime = DateTime.Now;

            context.ProcessOrder(order, list, store);
        }

        public List<Store> GetStores()
        {
            return _storeAppRepsitoryLayer.GetStores();
        }

    }
}
