using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msk.WebApp.ApiCollection;
using Msk.WebApp.Models;

namespace Msk.WebApp.Pages
{
    public class CartModel : PageModel
    {
        private readonly IBasketApi _basketApi;

        public CartModel(IBasketApi basketApi)
        {
            _basketApi = basketApi;
        }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketApi.GetBasket("johndoe");

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(string productId)
        {
            var cart  = await _basketApi.GetBasket("johndoe");

            var item = cart.Items.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                cart.Items.Remove(item);
                await _basketApi.CreateBasket(cart);
            }

            return RedirectToPage();
        }
    }
}