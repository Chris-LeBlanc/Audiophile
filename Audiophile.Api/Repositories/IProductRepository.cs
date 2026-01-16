using Audiophile.Models;

namespace Audiophile.Repositories;

public interface IProductRepository
{
    Task<ProductDto> GetProductAsync(int id);
    Task<List<ProductDto>> GetProductsAsync();
}
