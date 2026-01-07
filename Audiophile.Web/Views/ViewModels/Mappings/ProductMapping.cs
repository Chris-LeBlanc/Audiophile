using Audiophile.Models;
using Audiophile.Views;

namespace Audiophile.Mappings;

public class ProductMapping
{
    public static ProductViewModel ToProductViewModel(ProductListDto dto)
    {
        return new ProductViewModel()
        {
            Slug = dto.slug,
            Name = dto.name,
            CategoryId = dto.categoryId,
            IsNew = dto.isNew,
            Price = dto.price,
            Description = dto.description,
            Features = dto.features
        };
    }
}