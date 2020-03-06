using System;
using System.Collections.Generic;

namespace InventoryManagement.Models
{
    public partial class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
