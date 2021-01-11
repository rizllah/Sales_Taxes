using System;
using System.Diagnostics;


namespace Sales_Taxes
{
    public class Item{
        public Item(int id, string type,double price,string description, bool imported){
            Id = id;
            Type = type;
            Price = price;
            Description = description;
            Imported = imported;
        }

        public int Id{get; set;}
        public string Type{get; set;}
        public double Price{get; set;}
        public string Description{get; set;}
        public bool Imported{get; set;}


        public static void RequestNewItem(){ 
            double itemPrice = 0;
            string itemType = String.Empty, itemDescription = String.Empty;
            bool itemIsImported;
            String y;

            // Each loop repeats until correct info is provided for new inventory then porperties values are assigned to variables.

            while (true)
            {
                System.Console.WriteLine("Please enter Type of item - EX: Book, Music, Fashion, Health");
                y = System.Console.ReadLine();
                if (validated(y))
                {
                    if (y.Equals("0"))
                    // Go back to shoping list if user exits add new entry process
                    { Shared_Functions.GetShoppingList(); }
                    else
                    {
                        itemType = y;
                        break;
                    }
                }
                else System.Console.WriteLine("No value entered");    
            }

            while (true)
            {
                System.Console.WriteLine("Please enter Price of item - EX: 0.85, 27.99, 5.00");
                y = System.Console.ReadLine();
                if (validated(y))
                {
                    if (y.Equals("0"))
                        Shared_Functions.GetShoppingList();
                    else
                    {
                        //Try to convert user entry for price property into a double data type
                        if (Double.TryParse(y, out itemPrice))
                        {
                            break;
                        }
                        else System.Console.WriteLine("Invalid input");
                    }
                }
                else System.Console.WriteLine("No value entered");
            }


            while (true)
            {
                System.Console.WriteLine("Description of item - EX: Glass ornament");
                y = System.Console.ReadLine();
                if (validated(y))
                {
                    if (y.Equals("0"))
                    { Shared_Functions.GetShoppingList(); }
                    else
                    {
                        itemDescription = y;
                        break;
                    }
                }
                else System.Console.WriteLine("No value entered");
            }

         
            while (true)
            {
                System.Console.WriteLine("Is it imported? - Y | N");
                y = System.Console.ReadLine();
                if (validated(y))
                {
                    if (y.Equals("0"))
                        Shared_Functions.GetShoppingList();
                    else if (y.Equals("Y") || y.Equals("N"))
                    {
                        // Convert user string entry into bool data type for Item imported property.
                        itemIsImported = y == "Y" ? true : false;
                        break;
                    }
                    else
                    {
                        System.Console.WriteLine("Please enter Y or N or '0' to exit");
                    }
                }
            }
       

            // Create a new Item object from list of user specified properties
            Create_Item(itemType, itemPrice, itemDescription, itemIsImported);
            System.Console.WriteLine("\n");
            System.Console.WriteLine("#### New item successfully added ####");
            System.Console.WriteLine("\n");
        }
        
        
        public static void Create_Item(string type, double price, string description, bool import){

            Item newInventory = new Item(Stock.stockList.Count + 1, type, price, description, import);
            // Add new Item to stock
            Stock.AddItem(newInventory);

            // Print new stock list to user
            Stock.PrintStock(Stock.stockList);
        }

        // Return false if user provides no entry
        public static bool validated(){
            bool isValid  = System.Console.ReadLine().Equals(String.Empty) ? false:true;
            return isValid;
        }

        // Return false if user provides no entry
        public static bool validated(String x)
        {
            bool isValid = x.Length < 1 ? false : true;

            return isValid;
        }
    }

    

}
