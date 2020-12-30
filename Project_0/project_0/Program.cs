using System;
using System.Collections.Generic;
using System.Linq;

namespace project_0
{
    class Program
    {
        public static StoreAppRepsitoryLayer storeContext = new StoreAppRepsitoryLayer();
        public static Menus menus= new Menus();
        public static Customer CurrentCustomer = new Customer();
        public static Store myStorePick = new Store();
        public static int process = 0;
        public static bool firstTime = true;
        static void Main(string[] args)
        {
            int choice;
            int loginDone=0;
            do
            {
                if(firstTime == true)
                {
                    choice = menus.MainMenuWithoutLogin();
                    if( choice == 1)
                    {
                        Console.Clear();
                        CurrentCustomer = Login();
                        firstTime = false;
                        loginDone = menus.MainMenuWithLogin(CurrentCustomer);
                        if(loginDone == 1)
                        {
                            CurrentCustomer = new Customer();
                            choice = 0;
                            firstTime = true;
                        }
                        else if(loginDone == 2)
                        {
                            myStorePick = StoreSelection();
                            SecondaryMenu(myStorePick);
                        }
                        else if(loginDone == 3)
                        {
                            //This will take you to the order menu for the customer
                            //this is where they will be able to see what they have ordered
                            List<Orders> pastorders = new List<Orders>();
                            pastorders = storeContext.GetAllPastOrders(CurrentCustomer);
                            DisplayPastOrders(pastorders);

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
                            SecondaryMenu(myStorePick);
                        }
                        else if(loginDone == 3)
                        {
                            //This will take you to the order menu for the customer
                            //this is where they will be able to see what they have ordered
                            List<Orders> pastorders = new List<Orders>();
                            pastorders = storeContext.GetAllPastOrders(CurrentCustomer);
                            DisplayPastOrders(pastorders);
                        }
                    }
                    else if(choice == 3)
                    {
                        myStorePick = StoreSelection();
                        SecondaryMenu(myStorePick);
                                            
                    }
                    else if(choice == 4)
                    {
                        process = 1;
                    }

                }
                else
                {
                    loginDone = menus.MainMenuWithLogin(CurrentCustomer);
                    if(loginDone == 1)
                    {
                        CurrentCustomer = new Customer();
                        choice = 0;
                        firstTime = true;
                    }
                    else if(loginDone == 2)
                    {
                        myStorePick = StoreSelection();
                        SecondaryMenu(myStorePick);
                    }
                    else if(loginDone == 3)
                    {
                        //This will take you to the order menu for the customer
                        //this is where they will be able to see what they have ordered
                        List<Orders> pastorders = new List<Orders>();
                        pastorders = storeContext.GetAllPastOrders(CurrentCustomer);
                        DisplayPastOrders(pastorders);

                    }

                }

            }while(process == 0);

        }
        /// <summary>
        /// This is just a method to handle the store options once the customer
        /// has selected a store.1) View Cart 2) List Products 3) Checkout 4) Back
        /// </summary>
        /// <param name="store"></param>
        public static void SecondaryMenu(Store store)
        {
            int storeview;
            
            Console.WriteLine("Store View\n1) Press 1 for Yes\n2) Press 2 for No");
            storeview = menus.VaildateInput(Console.ReadLine(),2);
            if(storeview == 1)
            {
                bool sv = false;
                int options;
                do{
                    options = menus.StoreViewMenu(store);
                    if(options == 1)
                    {
                        List<Orders> pastorders = new List<Orders>();
                        pastorders = storeContext.GetAllStorePastOrders(store);
                        DisplayPastOrders(pastorders);

                    }
                    else if(options == 2)
                    {
                        string search = "";
                        List<Customer> storeCustomers = new List<Customer>();
                        while(search == ""){
                            Console.WriteLine("What Customer Name would you like to search?");
                            search = Console.ReadLine();
                        }

                        try{
                            storeCustomers = storeContext.GetListMatchingName(search);
                            if(storeCustomers.Count() != 0)
                            {
                                foreach(var c in storeCustomers)
                                {
                                    Console.WriteLine($"{c.firstName} {c.lastName} {c.favstore}");
                                }
                            }
                            else{
                                throw new Exception("There was No one matching the name you gave.");
                            }

                        }catch(Exception e)
                        {
                            Console.WriteLine(e);
                        }
                        storeCustomers = storeContext.GetListMatchingName(search);

                    }
                    else if(options == 3)
                    {
                        sv = true;
                    }


                }while(sv==false);
            }
            else
            {
                while(CurrentCustomer.firstName ==null)
                {
                    Console.WriteLine("Please Login to continue!");
                    CurrentCustomer = Login();
                    Console.WriteLine($"Welcome {CurrentCustomer.firstName} {CurrentCustomer.lastName} to \n");
                }
                List<Item> cart = new List<Item>();
                Item grabItem = new Item();
                
                //StoreLevelPrograms slp = new StoreLevelPrograms();
                int tracker = 0;
                do{
                    tracker = menus.StoreMenu(store);
                    if(tracker == 1)
                    {
                        showCart(cart);
                        tracker = 0;
                    }
                    else if(tracker == 2)
                    {
                        grabItem = StoreLevelPrograms.ProductSelection(storeContext,store);
                        storeContext.PremadeItemGrabed(grabItem);
                        storeContext.ItemWasGrabed(grabItem);
                        bool foundInCart = false;
                        foreach(var z in cart)
                        {
                            if(z.productId == grabItem.productId)
                            {
                                z.qty += grabItem.qty;
                                foundInCart = true;
                            }
                        }
                        if(foundInCart == false && grabItem.qty > 0)
                        {
                            cart.Add(grabItem);
                        }
                        tracker =0;
                    }
                    else if(tracker == 3)
                    {
                        StoreLevelPrograms.CheckOutCounter(storeContext,store,CurrentCustomer,cart);
                        cart = new List<Item>();
                        tracker =0;
                    }
                    else if(tracker == 4)
                    {
                        if(cart.Count != 0)
                        {
                            Console.WriteLine("You are leaving your cart of items! Goodbye!");
                            firstTime = false;

                        }
                        else{
                            Console.WriteLine($"Thank you for visiting {store.storeName}\nGoodbye!");
                            firstTime = false;
                        }
                    } 

                }while(tracker == 0);
            }
        }
        /// <summary>
        /// This will show the customer what they have in their cart. Will show them how 
        /// much the total is.
        /// </summary>
        /// <param name="a"></param>
        public static void showCart(List<Item> a)
        {
            Product temp = new Product();
            double tempTotal =0;
            foreach(var grab in a)
            {
                temp = storeContext.GetProduct(grab.productId);
                Console.WriteLine(grab.qty + " " + temp.ToString());
                tempTotal = tempTotal + (grab.qty*temp.price);
            }
            Console.WriteLine("Current Total: {0:0.00}",tempTotal);
        }
        /// <summary>
        /// Just where we get the first and last name of the customer. Returns Customer Object
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// The customer already knows they dont have an account so they want
        /// to make one. Returns Customer object
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Where a list is displayed and the customer chooses which one they
        /// want to go to. Returns the store object
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// This is a void method. It takes a List<Orders> as a parameter
        /// and will allow the user to select how to sort the orders or
        /// find the most expensive order or least.
        /// </summary>
        /// <param name="lo"></param>
        public static void DisplayPastOrders(List<Orders> lo)
        {
            bool sorter = false;
            int sort = 0;
            do{
                sort = menus.SortOrderMenu();
                Console.WriteLine();
                switch(sort)
                {
                    case 2:
                        var temp = lo.OrderByDescending(x => x.dateTime);
                        foreach(var der in temp)
                        {
                            Console.WriteLine($"At {der.stroeLocation.Id} was {der.total} ordered at {der.dateTime}");
                        }
                        break;
                    case 1:
                        var temp2 = lo.OrderBy(x => x.dateTime);
                        foreach(var der in temp2)
                        {
                            Console.WriteLine($"At {der.stroeLocation.Id} was {der.total} ordered at {der.dateTime}");
                        }
                        break;
                    case 3:
                        var least = lo.Min(x=> x.total);
                        Console.WriteLine(least.ToString());
                        break;
                    case 4:
                        var most = lo.Max(x=> x.total);
                        Console.WriteLine(most.ToString());
                        break;
                    case 5:
                        break;
                    case 6:
                        sorter = true;
                        break;
                }
                

            }while (sorter == false);
            Console.WriteLine();
        }
        
    }
}
