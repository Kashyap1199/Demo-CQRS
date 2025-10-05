namespace CQRS.Domain.Models
{
    public class Product
    {
        /// <summary>
        /// ID of the product.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name of the product.    
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Price of the product.   
        /// </summary>
        public decimal Price { get; set; }
    }
}