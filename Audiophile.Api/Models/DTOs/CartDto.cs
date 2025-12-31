namespace Audiophile.Models;

public record CartDto(Guid CartId, List<Product> Product, List<Image> Image, int Quantity, decimal Price, decimal SubTotal, decimal GrandTotal);


