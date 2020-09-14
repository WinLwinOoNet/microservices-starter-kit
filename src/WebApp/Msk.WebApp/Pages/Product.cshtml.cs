using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msk.WebApp.ApiCollection;
using Msk.WebApp.Models;

namespace Msk.WebApp.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ICatalogApi _catalogApi;
        private readonly IBasketApi _basketApi;

        public ProductModel(ICatalogApi catalogApi, IBasketApi basketApi)
        {
            _catalogApi = catalogApi;
            _basketApi = basketApi;
        }

        public IEnumerable<string> CategoryList { get; set; } = new List<string>();

        public IEnumerable<Models.ProductModel> ProductList { get; set; } = new List<Models.ProductModel>();

        [BindProperty(SupportsGet = true)]
        public string SelectedCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(string categoryName)
        {
            var products = await _catalogApi.GetProducts();
            CategoryList = products.Select(p => p.Category).Distinct();

            if (!string.IsNullOrWhiteSpace(categoryName))
            {
                ProductList = products.Where(p => p.Category == categoryName);
                SelectedCategory = categoryName;
            }
            else
            {
                ProductList = products;
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string productId)
        {
            var product = await _catalogApi.GetProduct(productId);

            var username = "johndoe";
            var basket = await _basketApi.GetBasket(username);

            basket.Items.Add(new BasketItemModel
            {
                ProductId = productId,
                ProductName = product.Name,
                Price = product.Price,
                Quantity = 1,
                Color = "Black"
            });

            await _basketApi.CreateBasket(basket);

            return RedirectToPage("Cart");
        }
    }
}