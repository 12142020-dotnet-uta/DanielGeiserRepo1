using System;
using System.Collections.Generic;

namespace Alt_project0
{
    class Program
    {
        public static StoreAppRepsitoryLayer storeContext = new StoreAppRepsitoryLayer();
        public static Menus menus= new Menus();
        public static Customer CurrentCustomer = new Customer();
        public static Store myStorePick = new Store();
        public static int process = 0;
        static void Main(string[] args)
        {
            int choice;
            int loginDone=0;
            do
            {
                choice = menus.MainMenuWithoutLogin();
                if( choice == 1)
                {
                    CurrentCustomer = Login();
                    loginDone = menus.MainMenuWithLogin(CurrentCustomer);
                    if(loginDone == 1)
                    {
                        CurrentCustomer = new Customer();
                        choice = 0;
                    }
                    else if(loginDone == 2)
                    {
                        myStorePick = StoreSelection();
                        SecondaryMenu(myStorePick,CurrentCustomer);
                    }
                    else if(loginDone == 3)
                    {
                        //This will take you to the order menu for the customer
                        //this is where they will be able to see what they have ordered

                    }

                }
                else if(choice == 2)
                {
                    CurrentCustomer = CreateTheCustomer();
                    loginDone = menus.MainMenuWithLogin(CurrentCustomer);
                    if(loginDone == 1)
                    {
                        CurrentCustomer = new Customer();
                        choice = 0;
                    }
                    else if(loginDone == 2)
                    {
                        myStorePick = StoreSelection();
                        SecondaryMenu(myStorePick,CurrentCustomer);
                    }
                    else if(loginDone == 3)
                    {
                        //This will take you to the order menu for the customer
                        //this is where they will be able to see what they have ordered
                        
                    }
                }
                else if(choice == 3)
                {
                    myStorePick = StoreSelection();
                    SecondaryMenu(myStorePick,CurrentCustomer);
                                        
                }
                else if(choice == 4)
                {
                    process = 1;
                }
                


            }while(process == 0);

        }
        
        public static void SecondaryMenu(Store store, Customer CCustomer)
        {
            //StoreLevelPrograms slp = new StoreLevelPrograms();
            int tracker = 0;
            store.CustomerGetsCart(CCustomer);
            do{
                tracker = menus.StoreMenu(store);
                if(tracker == 1)
                {
                    store.showCart();
                }
                else if(tracker == 2)
                {
                    store = StoreLevelPrograms.ProductSelection(storeContext,store,CCustomer);

                }
                else if(tracker == 3)
                {

                }
                else if(tracker == 4)
                {

                }

            }while(tracker == 0);
            
        }
        public static Customer Login()
        {
            Customer temp2 = new Customer();
            string Customer_F_N = "";
            string Customer_L_N = "";
            Console.WriteLine("\nLogin with");
            while(Customer_F_N =="")
            {
                Console.WriteLine("First Name: ");
                Customer_F_N = Console.ReadLine();
            }
            while(Customer_L_N=="")
            {
                 Console.WriteLine("Last Name: ");
                Customer_L_N = Console.ReadLine();
            }
            
            temp2 = storeContext.CreateCustomer(Customer_F_N,Customer_L_N);

            return temp2;
        }

        public static Customer CreateTheCustomer()
        {
            Customer temp2 = new Customer();
            string Customer_F_N = "";
            string Customer_L_N = "";
            Console.WriteLine("\nWelcome! Please enter the following information\n");
            while(Customer_F_N =="")
            {
                Console.WriteLine("First Name: ");
                Customer_F_N = Console.ReadLine();
            }
            while(Customer_L_N=="")
            {
                 Console.WriteLine("Last Name: ");
                Customer_L_N = Console.ReadLine();
            }
            
            temp2 = storeContext.CreateCustomer(Customer_F_N,Customer_L_N);

            return temp2;
        }

        public static Store StoreSelection()
        {
            Store myStore = new Store();
            List<Store> list = storeContext.GetStores();
            int pick = 0;
            do{
                foreach(var entry in list)
                {
                    Console.WriteLine(entry.ToString());
                }
                Console.WriteLine("\nWhich store would you like to go to?");
                pick = menus.VaildateInput(Console.ReadLine(),list.Count);
                myStore = storeContext.SelectTheStore(pick);

            }while(myStore == null);

            return myStore;
        }
        
    }
}
