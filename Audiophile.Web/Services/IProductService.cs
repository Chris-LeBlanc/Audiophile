using Audiophile.Models;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile.Services;

public interface IProductService
{
    Task<List<ProductListDto>> GetProductsAsync();
}