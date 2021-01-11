
using System;

namespace Sales_Taxes{
    public class Receipt{       
        public static void Print_Receipt(Cart customerCart){
            System.Console.WriteLine("\n");
            System.Console.WriteLine("Thank you for shopping!");
            System.Console.WriteLine("------------------------------");

            // Print details about cart items to user - accounting for item quantities
            foreach(Sale_Item item in Shared_Functions.cart){
                System.Console.WriteLine("{0}: {1:C} {2:C}", item.description, item.sale_price * item.quantity, item.quantity > 1 ? "(" + item.quantity + " @ " + Math.Round(item.sale_price, 2) + ")": "");
            }

            // Print totals and taxes for entire cart
            System.Console.WriteLine("Sales Taxes: {0:C}", customerCart.salesTax);
            System.Console.WriteLine("Total: {0:C}", customerCart.total);
            System.Console.WriteLine("\n");
        }
    }
}