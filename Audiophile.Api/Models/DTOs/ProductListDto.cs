using System.Diagnostics;

namespace Audiophile.Models;

public record ProductListDto(int ProductId, string Slug, string Name, int CategoryId, bool IsNew, decimal Price, string Description, string Features);
