using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Msk.WebApp.ApiCollection;
using Msk.WebApp.Models;

namespace Msk.WebApp.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IBasketApi _basketApi;

        public CheckOutModel(IBasketApi basketApi)
        {
            _basketApi = basketApi;
        }

        [BindProperty]
        public BasketCheckoutModel Order { get; set; }

        public BasketModel Cart { get; set; } = new BasketModel();

        public async Task<IActionResult> OnGetAsync()
        {
            Cart = await _basketApi.GetBasket("johndoe");
            return Page();
        }

        public async Task<IActionResult> OnPostCheckOutAsync()
        {
            string userName = "johndoe";
            Cart = await _basketApi.GetBasket(userName);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.UserName = userName;
            Order.TotalPrice = Cart.TotalPrice;

            await _basketApi.CheckoutBasket(Order);

            return RedirectToPage("Confirmation", "OrderSubmitted");
        }
    }
}