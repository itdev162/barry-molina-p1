using System;
using System.Linq;
using System.Collections.Generic;
using static System.Console;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // InitiateDb();
            MainMenu();



            //     MainMenu main = new MainMenu();

                // Console.WriteLine("Querying for a blog");
                // var blog = db.Blogs
                //     .OrderBy(b => b.BlogId)
                //     .First();

                // Console.WriteLine("Updating the blog and adding a post");
                // blog.Url = "https://devblogs.microsoft.com/dotnet";
                // blog.Posts.Add(
                //     new Post
                //     {
                //         Title = "Hello World",
                //         Content = "I wrote and app using EF Core!"
                //     });
                // db.SaveChanges();
                // Console.WriteLine("Delete the blog");
                // db.Remove(blog);
                // db.SaveChanges();
        }
        static void MainMenu()
        {
            while (true)
            {
                WriteLine(
                    "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                    "Welcome to the InventoryManager app\n" +
                    "\nPlease select one of the following options" +
                    "\n1. View your inventory items" +
                    "\n2. Search your inventory items by id" +
                    "\n3. Search your inventory items by name"
                );

                int select = Int32.Parse(ReadLine());

                switch (select) 
                {
                    case 1: 
                        ViewInventory();
                        break;
                }
            }
        }
        static void ViewInventory()
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
                    Write("\nEnter item number or 0 to return to the Main Menu: ");
                    int select = Int32.Parse(ReadLine());

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
        static void ManageInventoryItem(int itemId)
        {
            using (var db = new DataContext())
            {
                while (true)
                {
                    var item = db.InventoryItems.First(i => i.Id == itemId);
                    WriteLine(
                        "\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n" +
                        "Manage Inventory Item: " + item.Name +
                        "\n\nPlease select one of the following options" +
                        "\n1. Update Name" +
                        "\n2. Update Description" +
                        "\n3. Update Vendor" +
                        "\n4. Update Quantity In Stock" +
                        "\n5. Update Order At Quantity" +
                        "\n6. Update Last Order Date" +
                        "\n7. Update Next Order Date" +
                        "\n8. Update Order Price" +
                        "\n9. Delete item"
                    );
                    int select = Int32.Parse(ReadLine());

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
                            return;
                    }
                }
                // var inventoryItem = from item in db.InventoryItems
                //                     where item.Id == itemId
                //                     select item;
            }
        }
        static void UpdateName(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateDesc(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateVendor(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateOnHand(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateOrderAt(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateLastOrder(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateNextOrder(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void UpdateOrderPrice(int itemId)
        {
            using (var db = new DataContext())
            {
                var item = db.InventoryItems.First(i => i.Id == itemId);
            }
        }
        static void InitiateDb()
        {
            using (var db = new DataContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Console.WriteLine("Inserting a new inventory item");
                db.Add(new InventoryItem {
                    Name = "Knockoff Bluetooth Headphones",
                    Description = "They're not very good",
                    Vendor = "China",
                    QuantityOnHand = 8,
                    OrderAtQuantity = 2,
                    LastOrderDate = new DateTime(2020, 7, 18),
                    NextOrderDate = new DateTime(2020, 11, 18),
                    OrderPrice = 15.99m
                });
                db.Add(new InventoryItem {
                    Name = "Cheap Sunglasses",
                    Description = "They scratch up real easy",
                    Vendor = "Sunglass Hut",
                    QuantityOnHand = 15,
                    OrderAtQuantity = 5,
                    LastOrderDate = new DateTime(2020, 8, 10),
                    NextOrderDate = new DateTime(2021, 5, 1),
                    OrderPrice = 1.99m
                });
                db.SaveChanges();
            }
        }
    }
}
