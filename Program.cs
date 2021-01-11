using System;
using System.Collections.Generic;

namespace Sales_Taxes
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock.PrintStock(Stock.stockItems());
            Shared_Functions.GetShoppingList();
            Cart.Create_Cart(Shared_Functions.selectedItems);
            Receipt.Print_Receipt(Shared_Functions.customerCart);
        }
    }
}
