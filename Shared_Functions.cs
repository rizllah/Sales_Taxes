using System;
using System.Collections.Generic;

namespace Sales_Taxes
{
    public class Shared_Functions{
        public static List<Item> selectedItems = new List<Item>();
        public static List<Sale_Item> cart = new List<Sale_Item>();
        public static Cart customerCart;
        public static List<string> taxExemptTypes = new List<string>(){"Book", "Food", "Health"};
        public const double SALES_TAX = 0.1;
        public const double IMPORT_TAX = 0.05;
        public static string userInput = String.Empty;
     

        public static void GetShoppingList(){
            bool canConvert = false;            
            int selectedItem = 0;
            System.Console.WriteLine("\n");
            string msg = "Enter the number of the item to add to cart. Enter 0 to exit or 'Request' to add new item to inventory";
            string outOfStockMsg  = "Item is out of stock. Please enter 'Request' to request it or 'B' to go back.";

            while (true)
            {
                System.Console.WriteLine(msg);
                userInput = System.Console.ReadLine();

                // Check if user provided any data
                if (!userInput.Equals(string.Empty))
                {
                    canConvert = int.TryParse(userInput, out selectedItem);

                    // Check if data provided can be converted - if its a number value
                    if (canConvert)
                    {
                        if (selectedItem != 0)
                        {
                            // Check if item is in stock else notify user and re-prompt for correct data
                            if (Stock.ItemExists(selectedItem))
                                { selectedItems.Add(Stock.getStockItem(selectedItem)); }
                            else
                                { 
                                    System.Console.WriteLine(outOfStockMsg);
                                    userInput = System.Console.ReadLine();

                                    // Validate user entry. If user enter Request go to add new Item to inventory
                                    if (userInput.Equals("Request")) { Item.RequestNewItem(); if (true) { } }
                                    else if (userInput.Equals("B")) {  }
                                    else { System.Console.WriteLine("Invalid Input"); }
                            }
                        }
                        // Exit loop if user enters 0
                        if (selectedItem == 0)
                            break;
                    }

                    // Check if provided data can be converted to number (stock item id) else alert user and loop around with new prompt for data
                    if (!canConvert)
                    {
                        if (userInput.Equals("Request"))
                            Item.RequestNewItem();
                        else
                            System.Console.WriteLine("Invalid input"); 
                    }
                }
                else
                    System.Console.WriteLine("Invalid input");
            }

        }
        // Round to the nearest five cents.
        public static double roundToNearestFiveCents(double value){
            return Math.Round((Math.Round(value * 20, MidpointRounding.AwayFromZero) / 20),1);
        }
    }
}