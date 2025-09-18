using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared.DataTrancfareObject.BasketModuleDto;

namespace Presentation.Controllers
{
 
    public class BasketsController(IServiceManager _serviceManager) : ApiBaseController
    {

        // Get Basket
        [HttpGet] // GET BaseUrl/api/Basket
        public async Task<ActionResult<BasketDto>> GetBasket(string key)
        {
            var basket = await _serviceManager.BasketService.GetBasketAsync(key);
            return Ok(basket);
        }

        // Create Or Update Basket
        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdateBasket(BasketDto basket)
        {
            var Basket = await _serviceManager.BasketService.CreateOrUpdateBasketAsync(basket);
            return Ok(Basket);
        }

        // Delete Basket
        [HttpDelete("{Key}")]
        public async Task<IActionResult> DeleteBasket(string Key)
        {
           var Result = await _serviceManager.BasketService.DeleteBasketAsync(Key);
            return Ok(Result);
        }
    }
}
