using BlazorEcommerce.Shared;
using Microsoft.AspNetCore.Components;

namespace BlazorEcommerce
{
    public partial class ProductDetails : ComponentBase
    {
        [Inject]
        protected IProductService ProductService { get; set; }

        [Parameter]
        public int Id { get; set; }

        private Product product = null;
        private string message;

        protected override async Task OnParametersSetAsync()
        {
            message = "Loading product...";
            var result = await ProductService.GetProduct(Id);
            if (result.Success)
            {
                product = result.Data;
            }
            message = result.Message;
        }
    }
}