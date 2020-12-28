using System.Collections.Generic;
using System;

namespace project_0
{
    public class StoreLevelPrograms
    {

        public static Store ProductSelection(Store store,Customer cc)
        {
            List<Item> list = Program.storeContext.GetItemForStore(store.Id);
            Item tempItem = new Item();
            int pick = 0;
            int quantity = 0;
            int counter = 1;
            do{
                foreach(var entry in list)
                {
                    Console.WriteLine(counter + ") " + entry.ToString());
                    counter++;
                }
                Console.WriteLine("\nWhich Product would you like to get?");
                pick =Program.menus.VaildateInput(Console.ReadLine(),list.Count);
                tempItem = list[pick];
                Console.WriteLine("\nHow many of {0} would you like? Max is {1}",tempItem.product.productName, tempItem.qty);
                quantity = Program.menus.VaildateInput(Console.ReadLine(),tempItem.qty);

                tempItem.qty = quantity;
                store.AddtoCart(tempItem);

            }while(tempItem == null);

            return store;
        }
        
    }
}