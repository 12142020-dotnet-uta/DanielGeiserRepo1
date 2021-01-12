using Microsoft.AspNetCore.Authentication.Cookies;
using ModelLayer;
using ModelLayer.ViewModels;
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

        public List<StoreViewModel> ProductSelection(int store_id)
        {
            List<StoreViewModel> list = _storeAppRepsitoryLayer.GetItemForStore(store_id);

            return list;
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
