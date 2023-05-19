using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace CometFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _service;
        public OrdersController(OrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return await _service.GetAsync();
        }

        [HttpGet("{id:length(24)}", Name = "GetOrder")]
        public async Task<ActionResult<orderReturn>> Get(string id)
        {
            try
            {
                var order = await _service.GetAsync(id);
                if (order == null) { return NotFound(); }
                return _service.returnWith200(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Order>> Post(Order newOrder)
        {
            var data = new orderData();
            try
            {
                if (!_service.newOrderRules(newOrder, ref data))
                {
                    var responce = new orderErrorReturn { Errors = data };
                    await Response.WriteAsJsonAsync(responce);
                    return BadRequest(responce);
                }

                await _service.CreateAsync(newOrder);
                return CreatedAtRoute("GetUser", new { id = newOrder.Id }, _service.returnWith200(newOrder));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<ActionResult> Delete(string id)
        {
            var okReturn = new statusReturn();
            try
            {
                var order = await _service.GetAsync(id);
                if (order == null) { return NotFound(); }
                await _service.DeleteAsync(id);
                okReturn.Status = Response.StatusCode;
                return Ok(okReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
