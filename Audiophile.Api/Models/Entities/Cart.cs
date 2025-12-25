namespace Audiophile.Models
{
    public class Cart
    {
        public Guid CardId { get; set; }

        public User? User { get; set; }

        public List<Product>? Product { get; set; }

        public List<Image>? Image { get; set; }

        public int Quantity {get; set;}

        public decimal Price { get; set; }

        public decimal SubTotal { get; set; }

        public decimal GrandTotal { get; set; }

    }
}