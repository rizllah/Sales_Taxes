using System;
using System.Collections.Generic;

namespace Sales_Taxes
{
    public class Sale_Item : Item {
        public int id {get; set;}
        
        public string type {get; set;}
        public double unit_price {get; set;}
        public string description {get; set;}
        public bool imported {get; set;}
        public int quantity {get; set;}
        public double sale_price {get; set;}
        
       
        public Sale_Item(int id, string type,double price,string description, bool imported,int quantity) 
        : base(id, type, price, description, imported) {
            this.id = id;
            this.type = type;
            this.unit_price = price; 
            this.description = description;
            this.imported = imported;
            this.quantity = quantity;
            sale_price = calculateSalePrice(unit_price, quantity, type, imported);
        }

        // Calculate and return price after tax using item properties.
        public double calculateSalePrice(double itemPrice, int itemCount, string itemType, bool isImported){
            double priceAfterTax = itemPrice * itemCount;

            // Check the type of item to determine applicable taxes and rates.
            if (!Shared_Functions.taxExemptTypes.Contains(itemType)){
                if (isImported)
                    priceAfterTax = Shared_Functions.roundToNearestFiveCents(priceAfterTax * Shared_Functions.IMPORT_TAX) + Shared_Functions.roundToNearestFiveCents(priceAfterTax * Shared_Functions.SALES_TAX) + itemPrice;
                else
                    priceAfterTax = Shared_Functions.roundToNearestFiveCents(priceAfterTax * Shared_Functions.SALES_TAX)  + itemPrice;
            }
            // Check if item is imported to apply special import duty rates
            else if (isImported){
                priceAfterTax = Shared_Functions.roundToNearestFiveCents(priceAfterTax * Shared_Functions.IMPORT_TAX) + itemPrice;
            }
            return priceAfterTax;            
        }

    }

}