namespace Audiophile.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public Image? ProductImage { get; set; }

    }
}