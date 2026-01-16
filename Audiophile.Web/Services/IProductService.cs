using Audiophile.Models;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile.Services;

public interface IProductService
{
    Task<ProductDto> GetProductAsync(int id);
    Task<List<ProductDto>> GetProductsAsync();
}