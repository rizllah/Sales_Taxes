using System.Collections.Generic;
using System.Diagnostics;


namespace Sales_Taxes
{
    public class Cart {
        public List<Sale_Item> sales {get;set;}
        public double total{get; set;}
        public double salesTax{get; set;}

        public Cart(List<Sale_Item> sales) 
        {
            this.sales = Shared_Functions.cart;
            this.total = calculateTotal();
            this.salesTax = calculateSalesTax();
        }

        //Creat a cart from a list of items selected by user
        public static void Create_Cart(List<Item> userSelections){
            Dictionary<int, int> itemCount = new Dictionary<int, int>();
            foreach(Item item in userSelections){
                
                // Assign user specified quantity to item and make it a sale item
                Sale_Item saleItem = new Sale_Item(item.Id, item.Type, item.Price, item.Description, item.Imported, 1);

                //Increase item quantity if it already exists in cart else add to cart as 1 item.
                if (!itemCount.ContainsKey(saleItem.id)){
                    Shared_Functions.cart.Add(saleItem);
                    itemCount.Add(item.Id, 1);
                }
                else{
                    Shared_Functions.cart.Find(x => x.Id == saleItem.id).quantity++;
                    itemCount[item.Id]++;
                }
            }
            //Create a new cart object
            Shared_Functions.customerCart = new Cart(Shared_Functions.cart);
        }

        public double calculateTotal(){
            double totalSales = 0;
            //Calculate sale price by multipying unit price by quantity purchased.
            foreach(Sale_Item sold in sales){
                 totalSales += sold.sale_price * sold.quantity;
            }
            return totalSales;
        }

        public double calculateSalesTax(){
            double tax=0;
            //Calculate sales taxes applied by substracting unit price from sale price
            foreach(Sale_Item sold in sales){
                tax +=  ((sold.sale_price * sold.quantity) - (sold.unit_price * sold.quantity)); 
            }
            return tax;
        }

    }


}
