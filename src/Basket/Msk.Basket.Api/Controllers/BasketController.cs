using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Msk.Basket.Api.Entities;
using Msk.Basket.Api.Repositories;

namespace Msk.Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{userName}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> GetBasket(string userName)
        {
            var basket = await _repository.GetBasket(userName);
            return Ok(basket ?? new BasketCart(userName));
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> CreateBasket([FromBody] BasketCart basketCart)
            => Ok(await _repository.CreateBasket(basketCart));

        [HttpDelete("{userName}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.NoContent)]
        public async Task<ActionResult> DeleteBasket(string userName)
        {
            await _repository.DeleteBasket(userName);
            return NoContent();
        }

        /*[HttpPost]
        [Route("/Checkout")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.Created)]
        public async Task<ActionResult<BasketCart>> CheckoutBasket(BasketCart basketCart)
        {
            var basket = await _repository.CreateBasket(basketCart);
            return CreatedAtRoute(nameof(GetBasket), new { userName = basket.UserName }, basket);
        }*/
    }
}
