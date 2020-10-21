
using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace InventoryManager
{
    class Manager
    {
        public void MainMenu()
        {
            bool quit = false;
            while (!quit)
            {
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Welcome to the InventoryManager app\n" +
                    "\nPlease select one of the following options\n" +
                    "\n1. View your inventory items" +
                    "\n2. Add an inventory item" +
                    "\n3. Quit this application"
                );
                Write("\n>>> ");

                int select = Int32.Parse(ReadLine());

                switch (select) 
                {
                    case 1: 
                        ViewInventory();
                        break;
                    case 2: 
                        AddInventoryItem();
                        break;
                    case 3: 
                        quit = true;
                        break;
                }
            }
        }
        public void AddInventoryItem()
        {
            WriteLine(
                "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                "Add Inventory Item" + 
                "\n\n\nPress <enter> at any time to return to the Main Menu\n"
            );
            Write("\nEnter Name: ");
            string name = ReadLine();

            if (String.IsNullOrEmpty(name))
            {
                return;
            }
            Write("\nEnter Description: ");
            string description = ReadLine();
            if (String.IsNullOrEmpty(description))
            {
                return;
            }

            Write("\nEnter Vendor: ");
            string vendor = ReadLine();
            if (String.IsNullOrEmpty(vendor))
            {
                return;
            }

            Write("\nEnter Quantity On Hand: ");
            string onHand = ReadLine();
            if (String.IsNullOrEmpty(onHand))
            {
                return;
            }
            int qtyOnHand = Int32.Parse(onHand);

            Write("\nEnter Order At Quantity: ");
            string orderAt = ReadLine();
            if (String.IsNullOrEmpty(orderAt))
            {
                return;
            }
            int qtyOrderAt = Int32.Parse(orderAt);

            Write("\nEnter Last Order Date like mm/dd/yyy: ");
            string lastOrder = ReadLine();
            if (String.IsNullOrEmpty(lastOrder))
            {
                return;
            }
            DateTime lastOrderDate = DateTime.Parse(lastOrder);

            Write("\nEnter Next Order Date like mm/dd/yyy: ");
            string nextOrder = ReadLine();
            if (String.IsNullOrEmpty(nextOrder))
            {
                return;
            }
            DateTime nextOrderDate = DateTime.Parse(nextOrder);

            Write("\nEnter Order Price: ");
            string price = ReadLine();
            if (String.IsNullOrEmpty(price))
            {
                return;
            }
            decimal orderPrice = Decimal.Parse(price);

            using (var db = new DataContext())
            {
                db.InventoryItems.Add(
                    new InventoryItem
                    {
                        Name = name,
                        Description = description,
                        Vendor = vendor,
                        QuantityOnHand = qtyOnHand,
                        OrderAtQuantity = qtyOrderAt,
                        LastOrderDate = lastOrderDate,
                        NextOrderDate = nextOrderDate,
                        OrderPrice = orderPrice
                    }
                );
                db.SaveChanges();
            }
            Write("\n\nInventory item added. Press any key to return to return to the Main Menu");
            ReadKey();
        }
        public void ViewInventory()
        {
            while (true)
            {
                using (var db = new DataContext())
                {
                    List<int> itemIds = new List<int>();

                    int itemNumber = 0;
                    var items = db.InventoryItems;
                    string header = String.Format(
                        "{0,-33} {1,-30} {2,-20} {3,-10} {4,-10} {5,-15} {6,-15} {7,-10}",
                        "Item Name", "Item Description", "Vendor", "In Stock",
                        "Order At", "Last Ordered", "Next Order", "Price"
                    );
                    WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
                    WriteLine(header + "\n");

                    foreach (var item in items)
                    {
                        string itemInfo = String.Format(
                            "{0,-30} {1,-30} {2,-20} {3,-10} {4,-10} {5,-15} {6,-15} {7,-10}",
                            item.Name, item.Description, item.Vendor, item.QuantityOnHand,
                            item.OrderAtQuantity, String.Format("{0:d}",item.LastOrderDate), 
                            String.Format("{0:d}", item.NextOrderDate), item.OrderPrice
                        );
                        WriteLine((itemNumber+1) + ". " + itemInfo);
                        itemIds.Add(item.Id);
                        itemNumber++;
                    }
                    WriteLine("\nEnter item number to update or <enter> to return to the Main Menu: ");
                    Write("\n>>> ");
                    string ans = ReadLine();

                    if (String.IsNullOrEmpty(ans))
                    {
                        return;
                    }
                    int select = Int32.Parse(ans);

                    if (select == 0)
                    {
                        return;
                    }
                    else
                    {
                        ManageInventoryItem(itemIds[select - 1]);
                    }
                }
            }
        }
        public void ManageInventoryItem(int itemId)
        {
            bool itemDeleted = false;
            while (!itemDeleted)
            {
                using (var db = new DataContext())
                {
                    var item = db.InventoryItems.First(i => i.Id == itemId);
                    WriteLine(
                        "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                        "Manage Inventory Item: '" + item.Name + "'" +
                        "\n\n\nPlease select one of the following attributes to update\n" +
                        "\nPress <enter> to return to the Inventory Items Menu\n" +
                        "\n1. Name" +
                        "\n2. Description" +
                        "\n3. Vendor" +
                        "\n4. Quantity In Stock" +
                        "\n5. Order At Quantity" +
                        "\n6. Last Order Date" +
                        "\n7. Next Order Date" +
                        "\n8. Order Price" +
                        "\n\n9. Delete item"
                    );
                    Write("\n>>> ");
                    string ans = ReadLine();

                    if (String.IsNullOrEmpty(ans))
                    {
                        return;
                    }
                    int select = Int32.Parse(ans);
                    switch (select) 
                    {
                        case 1: 
                            UpdateName(itemId);
                            break;
                        case 2: 
                            UpdateDesc(itemId);
                            break;
                        case 3: 
                            UpdateVendor(itemId);
                            break;
                        case 4: 
                            UpdateOnHand(itemId);
                            break;
                        case 5: 
                            UpdateOrderAt(itemId);
                            break;
                        case 6: 
                            UpdateLastOrder(itemId);
                            break;
                        case 7: 
                            UpdateNextOrder(itemId);
                            break;
                        case 8: 
                            UpdateOrderPrice(itemId);
                            break;
                        case 9: 
                            itemDeleted = DeleteInventoryItem(itemId);
                            break;
                    }
                }
                // var inventoryItem = from item in db.InventoryItems
                //                     where item.Id == itemId
                //                     select item;
            }
        }
        public void UpdateName(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Name for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newName = ReadLine();
                if (!String.IsNullOrEmpty(newName))
                {
                    item.Name = newName;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateDesc(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Description for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newDescription = ReadLine();
                if (!String.IsNullOrEmpty(newDescription))
                {
                    item.Description = newDescription;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateVendor(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Vendor for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newVendor = ReadLine();
                if (!String.IsNullOrEmpty(newVendor))
                {
                    item.Vendor = newVendor;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateOnHand(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Quantity on Hand for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newOnHand = ReadLine();
                if (!String.IsNullOrEmpty(newOnHand))
                {
                    int newQuantity = Int32.Parse(newOnHand);
                    item.QuantityOnHand = newQuantity;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateOrderAt(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Order At Quantity for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newOrderAt = ReadLine();
                if (!String.IsNullOrEmpty(newOrderAt))
                {
                    int newQuantity = Int32.Parse(newOrderAt);
                    item.OrderAtQuantity = newQuantity;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateLastOrder(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Last Order Date for item '" + item.Name + 
                    "'\n\nlike this: mm/dd/yyyy or <enter> to abort"
                );
                Write("\n>>> ");
                string newLastOrder = ReadLine();
                if (!String.IsNullOrEmpty(newLastOrder))
                {
                    DateTime newDate = DateTime.Parse(newLastOrder);
                    item.LastOrderDate = newDate;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateNextOrder(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Next Order Date for item '" + item.Name + 
                    "'\n\nlike this: mm/dd/yyyy or <enter> to abort"
                );
                Write("\n>>> ");
                string newNextOrder = ReadLine();
                if (!String.IsNullOrEmpty(newNextOrder))
                {
                    DateTime newDate = DateTime.Parse(newNextOrder);
                    item.NextOrderDate = newDate;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public void UpdateOrderPrice(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Enter new Order Price for item '" + item.Name + 
                    "'\n\nPress <enter> to abort"
                );
                Write("\n>>> ");
                string newOrderPrice = ReadLine();
                if (!String.IsNullOrEmpty(newOrderPrice))
                {
                    decimal newQuantity = Decimal.Parse(newOrderPrice);
                    item.OrderPrice = newQuantity;
                    db.SaveChanges();
                    Write("\nInventory item updated. Press any key to return to Item Menu");
                    ReadKey();
                }
            }
        }
        public bool DeleteInventoryItem(int itemId)
        {
            bool deleted = false;
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Are you sure you want to delete item '" + item.Name + 
                    "'? y/n:"
                );
                Write("\n>>> ");
                string deleteItem = ReadLine();
                if (deleteItem == "y" || deleteItem == "Y")
                {
                    db.Remove(item);
                    db.SaveChanges();
                    deleted = true;
                    Write("\nInventory item deleted. Press any key to return to the Main Menu");
                }
                else
                {
                    Write("\nDelete inventory item aborted. Press any key to return to Item Menu");
                }
                ReadKey();
            }
            return deleted;
        }
    }
}
