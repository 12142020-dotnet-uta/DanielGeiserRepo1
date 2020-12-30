using System;
using System.Collections.Generic;

namespace project_0
{
    public class Menus
    {
        //private int options1 = 1;
        //private int options2 = 2;
        private int options3 = 3;
        private int options4 = 4;
        private int options6 = 6;

        /// <summary>
        /// This will continue to show the Main menu until an acceptable 
        /// entry is made.
        /// </summary>
        /// <returns></returns>
        public int MainMenuWithoutLogin()
        {
            //login, quit, new customer , view stores, 
            int step1 = 0;
            do{
                Console.WriteLine("Welcome to Kingdom\nThe one stop shop for all your kingdom needs.");
                Console.WriteLine("1) Login\n2) New Customer\n3) Store list\n4) Quit");
                step1 = VaildateInput(Console.ReadLine(),options4);

            }while(step1 == 0);
            return step1;
        }
        /// <summary>
        /// This is the menu for somone who has Logged in.
        /// </summary>
        /// <param name="cc"></param>
        /// <returns></returns>
        public int MainMenuWithLogin(Customer cc)
        {
            //logout, quit, view stores, 
            int step1 = 0;
            do{
                Console.WriteLine("Welcome {0} {1} to Kingdom\nThe one stop shop for all your kingdom needs.",cc.firstName,cc.lastName);
                Console.WriteLine("1) Logout\n2) Store list\n3) View your Past Oders");
                step1 = VaildateInput(Console.ReadLine(),options3);

            }while(step1 == 0);
            return step1;
        }


        /// <summary>
        /// This is the store menu. It accepts a Store class object to get the informaiton 
        /// inside.
        /// </summary>
        /// <param name="picked"></param>
        /// <returns></returns>
        public int StoreMenu(Store picked)
        {
            //past orders, view cart, back to store list, view products, checkout, logout- back to main menu

            int step2 = 0;
            do{
                Console.WriteLine("{1} {0}\n__________________\nWhat can we help you with?",picked.location,picked.storeName);
                Console.WriteLine("1) View Cart\n2) List Products\n3) Checkout\n4) Back");
                step2 = VaildateInput(Console.ReadLine(),options4);

            }while(step2 == 0);
            return step2;
        }

        public void CustomerMenu(Customer cus)
        {
            int cusM = 0;
            // list of the customers orders or options by store, low to high, high to low,
            // least expensive trip, most expensive trip
            do{
                Console.WriteLine("Hello, {0} {1}\nHow may we help you?",cus.firstName,cus.lastName);
                Console.WriteLine("1) View past orders\n2) View Stores Visited\n3) Back");
                cusM = VaildateInput(Console.ReadLine(),options3);

            }while(cusM ==0);
        }

        public int SortOrderMenu()
        {
            int sorter = 0;
            do{
                Console.WriteLine("How would you like to sort the list");
                Console.WriteLine("1) Earliest\n2) Lastest\n3) Least expensive order"+
                            "\n4) Most expensive\n5) Full Order Details\n6) Back");
                sorter = VaildateInput(Console.ReadLine(),options6);

            }while(sorter==0);
            return sorter;
        }
        /// <summary>
        /// This gives a store view which allows the viewing of all orders from that store
        /// and to find a customer by name
        /// </summary>
        /// <param name="selection"></param>
        public int StoreViewMenu(Store selection)
        {
            // This is where a order will be viewed as a whole
            // the menu before will only have the store, amount charged, but this will
            // have all the items, how many of them were ordered, and everything else.
            int response = 0;
            do{
                Console.WriteLine("Hello, {0} {1} Total Sales {2}\nWhat do you want to see about the Store?",selection.storeName,selection.location,selection.totalSales);
                Console.WriteLine("1) All Orders at this Store\n2) Find Customer by Name\n3) Back");
                response = VaildateInput(Console.ReadLine(),options3);

            }while(response == 0);
           return response;
        }
        /// <summary>
        /// This function accepts a string from ReadLine and will vaildate from a number 
        /// which falls between 1 and whatever option was passed in.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public int VaildateInput(string input,int a)
        {
            int response = 0;
            bool tempResp;
            bool anOut = false;
            do{
                tempResp = int.TryParse(input, out response);
                if(tempResp==false)
                {
                    Console.WriteLine($"Please enter number from 1 to {a} only!");
                    input = Console.ReadLine();
                    response = 0;
                }
                else if(response < 0)
                {
                    Console.WriteLine($"Please enter number from 1 to {a} only!");
                    input = Console.ReadLine();
                    response = 0;
                }
                else if(response > a)
                {
                    Console.WriteLine($"Please enter number from 1 to {a} only!");
                    input = Console.ReadLine();
                    response = 0;
                }
                else if(response == 0)
                {
                    response = 1;
                    anOut = true;
                }
                else{
                    anOut=true;
                }
            }while(anOut == false);
            
            return response;
        }

        public void OrderFullDetail(List<Orders> list)
        {
            Orders tempOrder = new Orders();
            int pick = 0;
            int quantity = 0;
            int counter = 1;
            int Checkqty;

            do{
                foreach(var entry in list)
                {
                    Console.WriteLine(counter + ") " + entry.ToString());
                    counter++;
                }
                Console.WriteLine("\nWhich Product would you like to get?");
                pick =Program.menus.VaildateInput(Console.ReadLine(),list.Count);
                tempOrder = list[pick-1];
            }while(tempOrder == null);

        }
    }
}