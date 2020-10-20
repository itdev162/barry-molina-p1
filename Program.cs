using System;
using System.Linq;
using static System.Console;

namespace InventoryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                WriteLine(
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
                        using (var db = new DataContext())
                        {
                            var items = db.InventoryItems;
                            foreach (var item in items)
                            {
                                WriteLine(item.Name);
                            }

                        }
                        break;

                }


            // using (var db = new DataContext())
            // {
            //     db.Database.EnsureDeleted();
            //     db.Database.EnsureCreated();

            //     Console.WriteLine("Inserting a new inventory item");
            //     db.Add(new InventoryItem {
            //         Name = "Knockoff Bluetooth Headphones",
            //         Description = "They're not very good",
            //         Vendor = "China",
            //         QuantityOnHand = 8,
            //         OrderAtQuantity = 2,
            //         LastOrderDate = new DateTime(2020, 7, 18),
            //         NextOrderDate = new DateTime(2020, 11, 18),
            //         OrderPrice = 15.99m
            //     });
            //     db.SaveChanges();

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
        }
    }
}
