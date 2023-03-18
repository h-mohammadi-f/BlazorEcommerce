using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();
        private readonly HttpClient _http;

        public event Action ProductChanged;

        public ProductService(HttpClient http)
        {
            _http = http;
        }

        public async Task GetProducts(string categoryUrl = null)
        {
            if (_http != null)
            {
                var result = categoryUrl==null?
                 await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>("api/Product"):
                 await _http.GetFromJsonAsync<ServiceResponse<List<Product>>>($"api/product/category/{categoryUrl}");
                if (result != null && result.Data != null)
                {
                    Products = result.Data;
                }
                ProductChanged.Invoke();
            }
        }

        public async Task<ServiceResponse<Product>> GetProduct(int productId)
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<Product>>($"api/product/{productId}");
            return result;
        }
    }
}