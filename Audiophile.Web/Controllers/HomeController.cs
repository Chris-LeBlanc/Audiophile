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
    public async Task<IActionResult> GetProductAsync(int id)
    {
        var product = await _productService.GetProductAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        var productVm = ProductMapping.ToProductViewModel(product);

        return View(productVm);
    }

    [HttpGet]
    public async Task<ActionResult<List<ProductViewModel>>> Index()
    {
        var products = await _productService.GetProductsAsync();

        if (products == null)
        {
            return NotFound();
        }

        var productsVm = products
            .Select(ProductMapping.ToProductViewModel)
            .ToList();

        return View(productsVm);
    }
}
