using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using Audiophile.Models;
using Audiophile.Options;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Audiophile.Services;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly OptionsConfig _options;

    public ProductService(HttpClient httpClient, IOptions<OptionsConfig> options)
    {
        _httpClient = httpClient;
        _options = options.Value;

    }

    public async Task<ProductDto> GetProductAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_options.BaseUrl}{_options.Products}{id}");

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                var product = JsonSerializer.Deserialize<ProductDto>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

                return product;
            }

            return null;
        }
        catch (Exception ex)
        {
            throw new DllNotFoundException("Cannot find products requested", ex);
        }
    }

    public async Task<List<ProductDto>> GetProductsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync($"{_options.BaseUrl}{_options.Products}");

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();

                var products = JsonSerializer.Deserialize<List<ProductDto>>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return products != null ? products : new List<ProductDto>();
            }

            return new List<ProductDto>();
        }
        catch (Exception ex)
        {
            throw new DllNotFoundException("Cannot find products requested", ex);
        }
    }
}