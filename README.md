# Sales_Taxes

Item:
An Item object is created as a base class with properties which will be inherited.

Stock:
A Stock object is created in which a list of Items are stored as the store’s inventory. In the Stock class, there is a PrintStock method which displays the list of items in stock to the user. 

Get Shopping List:
The user is prompted to select an item from the stock list repeatedly until ‘0’ is entered  to stop adding items. At this point the loop is terminated. Each entry is validated and the user is prompted to try again with a correct entry if incorrect. All correct user entries are saved as a list.

Request New Item:
A user is prompted to add an item to inventory if the item being purchased is out of stock. In the RequestNewItem function, the user is prompted to provide values for the new Item’s properties. All property values are stored in a list and used to create an Item object which is added to the inventory and then included in a stock list displayed to the user for addition to cart.

Cart:
The list is sent to the CreateCart method in the Cart class where each item is used to create a derived Sale_Item object. A Sale_Item has a user specified quantity. The quantity property of a Sale_Item together with its Item inherited type, price and imported properties are used to calculate its sale price. Totals and SalesTax property of the Cart are calculated  using methods in the class.

Receipt:
The Print_Receipt method loops through all Sale_Items in the Cart parameter and writes relevant information about the entire sale to the console as a receipt for the user.
