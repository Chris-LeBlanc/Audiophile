using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Audiophile.Mappings;
using Audiophile.Models;
using Audiophile.Services;
using Audiophile.Views;

namespace Audiophile.Web.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;
    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductViewModel>>> Index()
    {
        var products = await _productService.GetProductsAsync();

        var productsVm = products
            .Select(ProductMapping.ToProductViewModel)
            .ToList();

        return View(productsVm);
    }
}
