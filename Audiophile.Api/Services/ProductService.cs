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

    public async Task<ProductDto> GetProductAsync(int id)
    {
        return await _productRepository.GetProductAsync(id);
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        return await _productRepository.GetProductsAsync();
    }
}
