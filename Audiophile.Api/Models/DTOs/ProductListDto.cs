namespace Audiophile.Models;

public record ProductListDto(Guid productId, string name, string description, decimal price);
