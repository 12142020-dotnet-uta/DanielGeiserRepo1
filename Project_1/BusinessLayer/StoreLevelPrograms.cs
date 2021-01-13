using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
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
        public void AddToCart(StoreViewModel svm,HttpContext context)
        {
            Item item = new Item();
            item.Id_TO_S = svm.ID_store;
            item.productId = svm.productId;
            item.qty = svm.qty;
            item.sale = svm.sale;
            Cart cart = new Cart();
            cart.customerGuild = context.Session.GetString("Guid");
            cart.amountPicked = svm.qty;
            _storeAppRepsitoryLayer.AddToCart(item,cart);
        }

        public List<Store> GetStores()
        {
            return _storeAppRepsitoryLayer.GetStores();
        }

        public List<Cart> GetCartItems(string customerGuidtoString)
        {
            return _storeAppRepsitoryLayer.GetCartItems(customerGuidtoString);
        }

        public List<Orders> AllPastOrders(string customerid)
        {
            return _storeAppRepsitoryLayer.GetAllPastOrders(customerid);
        }

        public List<FullOrderViewModel> GetFullOrderDetails(int id)
        {
            List<FullOrderViewModel> fullorder = new List<FullOrderViewModel>(); 
            fullorder = _storeAppRepsitoryLayer.FullOrderDisplay(id);
            return fullorder;
        }

    }
}
