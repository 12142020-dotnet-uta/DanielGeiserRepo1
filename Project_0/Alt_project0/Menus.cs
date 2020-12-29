using System;

namespace Alt_project0
{
    public class Menus
    {
        private int options1 = 1;
        private int options2 = 2;
        private int options3 = 3;
        private int options4 = 4;
        private int options5 = 5;

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
                Console.WriteLine("Welcome to Kingdom\nThe one stop shop for all you kingdom needs.");
                Console.WriteLine("1) Login\n2) New Customer\n3) Store list\n4) Quit");
                step1 = VaildateInput(Console.ReadLine(),options4);

            }while(step1 == 0);
            return step1;
        }
        
        public int MainMenuWithLogin(Customer cc)
        {
            //logout, quit, view stores, 
            int step1 = 0;
            do{
                Console.WriteLine("Welcome {0} {1} to Kingdom\nThe one stop shop for all you kingdom needs.",cc.firstName,cc.lastName);
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
                Console.WriteLine("1) View Cart\n2) List Products\n3) Checkout\n4) Logout");
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
        public void CustomerOrderMenu(Customer cus)
        {
            // This is where a order will be viewed as a whole
            // the menu before will only have the store, amount charged, but this will
            // have all the items, how many of them were ordered, and everything else.
            int response = 0;
            do{
                Console.WriteLine("Hello, {0} {1}\nHow may we help you?",cus.firstName,cus.lastName);
                Console.WriteLine("1) Back");
                response = VaildateInput(Console.ReadLine(),options1);

            }while(response == 0);
           
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
            bool tempResp = int.TryParse(input, out response);
            if(tempResp==false)
            {
                Console.WriteLine("Please enter number from 1 to {o} only!",a);
                response =0;
            }
            else if(response < 0 || response > a)
            {
                response =0;
            }
            return response;
        }
    }
}