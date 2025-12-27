using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Audiophile.Web.Models;
using Audiophile.Models;
using Audiophile.Services;

namespace Audiophile.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<List<ProductListDto>> Index()
    {
        return await _productService.GetProductsAsync();
    }
}
