using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce
{
    public partial class ProductList : ComponentBase, IDisposable
    {
        [Inject]
        protected IProductService ProductService { get; set; }

        protected override void OnInitialized()
        {
            ProductService.ProductChanged += StateHasChanged;
        }

        public void Dispose()
        {
            ProductService.ProductChanged -= StateHasChanged;
        }
    }
}