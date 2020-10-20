using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager
{
    public class DataContext: DbContext
    {
        public DbSet<InventoryItem> InventoryItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Inventory.db");
    }

    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Vendor { get; set; }
        public int QuantityOnHand { get; set; }
        public int OrderAtQuantity { get; set; }
        public DateTime LastOrderDate { get; set; }
        public DateTime NextOrderDate { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
