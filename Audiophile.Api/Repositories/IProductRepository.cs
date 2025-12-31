using Audiophile.Models;

namespace Audiophile.Repositories;

public interface IProductRepository
{
    Task<List<ProductListDto>> GetProductsAsync();
}
