using Audiophile.Models;

namespace Audiophile.Services;

public interface IProductService
{
    Task<ProductDto> GetProductAsync(int id);
    Task<List<ProductDto>> GetProductsAsync();
}
