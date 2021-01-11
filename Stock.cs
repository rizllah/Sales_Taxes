using System;
using System.Collections.Generic;

namespace Sales_Taxes{
    public class Stock{
        public static List<Item> stockList = new List<Item>();
        public static List<Item> stockItems(){
            Item Item1 = new Item(1,"Book", 12.49, "Book", false);
            Item Item2 = new Item(2,"Music", 14.99, "Music CD", false);
            Item Item3 = new Item(3,"Food", 0.85, "Chocolate bar", false);
            Item Item4 = new Item(4,"Food", 10.00, "Imported box of chocolates", true);
            Item Item5 = new Item(5,"Food", 11.25, "Imported box of chocolates", true);
            Item Item6 = new Item(6,"Fashion", 47.50, "Imported bottle of perfume", true);
            Item Item7 = new Item(7,"Fashion", 27.99, "Imported bottle of perfume", true);
            Item Item8 = new Item(8,"Fashion", 18.99, "Bottle of perfume", false);
            Item Item9 = new Item(9,"Health", 9.75, "Packet of headache pills", false);
            stockList = new List<Item> {Item1, Item2, Item3, Item4, Item5, Item6, Item7, Item8, Item9};
            return stockList;
        }

        // Return a specicfied item from available in stock
        public static Item getStockItem(int stockId){
            return stockList.Find(x => x.Id == stockId);
        }

        public static void PrintStock(List<Item> StockList){
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Items in stock");
            System.Console.WriteLine("-------------------------------");

            // Print formated Item info as list of in stock items for sale
            foreach(Item x in StockList){
                System.Console.WriteLine("{0}. {1}-------{2:0.00}", x.Id, x.Description, x.Price);
            }
        }

        public static void AddItem(Item newItem){
            stockList.Add(newItem);
        }

        // Return true if item exists in stock list
        public static bool ItemExists(int id)
        {
            return Stock.stockList.Contains(Stock.getStockItem(id));
        }
    }
    
}