using System.Runtime.InteropServices.Marshalling;
using Audiophile.Models;
using Audiophile.Services;
using Microsoft.AspNetCore.Mvc;

namespace Audiophile.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ProductDto> GetProduct(int id)
    {
        return await _productService.GetProductAsync(id);
    }

    [HttpGet]
    public async Task<List<ProductDto>> Index()
    {
        return await _productService.GetProductsAsync();
    }
}
