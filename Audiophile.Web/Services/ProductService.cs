using System.Net;
using System.Text.Json;
using Audiophile.Models;
using Audiophile.Options;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;

namespace Audiophile.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly OptionsConfig _options;

        public ProductService(HttpClient httpClient, IOptions<OptionsConfig> options)
        {
            _httpClient = httpClient;
            _options = options.Value;

        }
        public async Task<List<ProductListDto>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync($"{_options.BaseUrl}{_options.Products}");

           if (response.IsSuccessStatusCode)
            {
                var stream = await response.Content.ReadAsStreamAsync();
                var dto = await JsonSerializer.DeserializeAsync<List<ProductListDto>>(stream);
                return dto.ToList();
            }

            return response.StatusCode == HttpStatusCode.OK ? new List<ProductListDto>() : new List<ProductListDto>();
        }
    }
}