using System.Data.Entity;

namespace ProductsWebApi.Areas.ProductArea.Models
{
    public class ProductDB: DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}