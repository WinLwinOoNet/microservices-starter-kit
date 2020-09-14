using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msk.WebApp.ApiCollection;
using Msk.WebApp.Models;

namespace Msk.WebApp.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IBasketApi _basketApi;

        public ProductDetailModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public Models.ProductModel Product { get; set; }

        [BindProperty]
        public string Color { get; set; }

        [BindProperty]
        public int Quantity { get; set; }

        public async Task<IActionResult> OnGetAsync(string productId)
        {
            if (string.IsNullOrEmpty(productId))
                return NotFound();

            Product = await _catalogApi.GetProduct(productId);
            if (Product == null)
                return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogApi.GetProduct(productId);

            string username = "johndoe";
            BasketModel basket = await _basketApi.GetBasket(username);
            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = Quantity,
                Color = Color
            });
            await _basketApi.CreateBasket(basket);
            return RedirectToPage("Cart");
        }
    }
}