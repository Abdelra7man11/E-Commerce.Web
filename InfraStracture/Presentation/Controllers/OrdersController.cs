//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using ServiceAbstraction;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;

//namespace Presentation.Controllers
//{
//    [Authorize]
//    [Route("api/[controller]")] //BaseUrl/api/Order
//    [ApiController]
//    public class OrdersController(IServiceManager _serviceManager) : ControllerBase
//    {

//        [HttpPost]
//        public async Task<ActionResult<OrderResponse>> Create(OrderRequest request)
//        {
//            var email = User.FindFirstValue(ClaimTypes.Email);
//            var res = await _serviceManager.OrderService.CreateAsync(request, email);
//            return Ok(res);
//        }


//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get()
//        {
//            var email = User.FindFirstValue(ClaimTypes.Email);

//            return Ok(await _serviceManager.OrderService.GetAllAsync(email));

//        }

//        [HttpGet("{id:guid}")]///BaseUrl/api/Order/
//        public async Task<ActionResult<OrderResponse>> Get(Guid id)
//        {
//            return Ok(await _serviceManager.OrderService.GetByIdAsync(id));
//        }


//        [AllowAnonymous]
//        [HttpGet("deliveryMethods")]
//        public async Task<ActionResult<IEnumerable<DeliveryMethodResponse>>> GetDeliveryMethods()
//        {
//            return Ok(await _serviceManager.OrderService.GetDeliveryMethodsAsync());
//        }
//    }
//}
