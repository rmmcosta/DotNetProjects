namespace ProductsWebApi.Areas.ProductArea.Models
{
    /// <summary>
    /// The Product
    /// </summary>
    public class Product
    {
        /// <summary>
        /// internal identifier
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// the name of the product
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// the price of the product
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// the number of units available
        /// </summary>
        public int UnitsInStock { get; set; }
    }
}