namespace Audiophile.Models;

public record ProductDto(int productId, string slug, string name, int categoryId, bool isNew, decimal price, string description, string features);

