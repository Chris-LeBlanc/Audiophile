using Audiophile.Models;

namespace Audiophile.Services;

public interface IProductService
{
    Task<List<ProductListDto>> GetProductsAsync();
}
