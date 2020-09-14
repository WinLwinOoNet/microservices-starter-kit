using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msk.WebApp.ApiCollection;
using Msk.WebApp.Models;

namespace Msk.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IBasketApi _basketApi;

        public IndexModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public IEnumerable<Models.ProductModel> ProductList { get; set; } = new List<Models.ProductModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ProductList = await _catalogApi.GetProducts();
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            Models.ProductModel product = await _catalogApi.GetProduct(productId);

            string username = "johndoe";
            BasketModel basket = await _basketApi.GetBasket(username);
            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "Black"
            });
            basket = await _basketApi.CreateBasket(basket);
            return RedirectToPage("Cart");
        }
    }
}
