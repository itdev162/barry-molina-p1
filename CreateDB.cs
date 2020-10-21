
using System;
using System.Linq;

namespace InventoryManager
{
    class CreateDB
    {
        public void InitiateDb()
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