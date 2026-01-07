using System.Diagnostics;

namespace Audiophile.Models;

public record ProductListDto(int productId, string slug, string name, int categoryId, bool isNew, decimal price, string description, string features);
