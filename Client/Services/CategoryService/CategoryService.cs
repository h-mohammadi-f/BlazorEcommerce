using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazorEcommerce.Shared;

namespace BlazorEcommerce.Client.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        private readonly HttpClient _http;

        public CategoryService(HttpClient http)
        {
            _http = http;

        }

        public async Task GetCategoriesAsync()
        {
            if (_http != null)
            {
                var result = await _http.GetFromJsonAsync<ServiceResponse<List<Category>>>("api/Category");
                if (result != null && result.Data != null)
                {
                    Categories = result.Data;
                }
            }
        }

        public Task<ServiceResponse<Category>> GetCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}