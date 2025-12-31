using System.Threading.Tasks;
using Audiophile.Models;
using Audiophile.Repositories;

namespace Audiophile.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<List<ProductListDto>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }
}
