using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace CometFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _service;

        public ShopsController(ShopService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Shop>>> Get()
        {
            return await _service.GetAsync();
        }

        [HttpGet("{name}", Name = "GetShopByName")]
        public async Task<ActionResult<shopReturn>> Get(string name)
        {
            try
            {
                var shop = await _service.GetAsync(name);
                if (shop == null) { return NotFound(); }
                return _service.returnWith200(shop); ;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> Post(Shop newShop)
        {
            try
            {
                var shop = await _service.GetAsync(newShop.Name);
                if (shop == null)
                {
                    await _service.CreateAsync(newShop);
                    return CreatedAtRoute("GetShopByName", new { name = newShop.Name }, _service.returnWith200(newShop));
                }
                return BadRequest("this shop is already registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{name}")]
        public async Task<IActionResult> Update(string name, Shop updatedShop)
        {
            var okReturn = new statusReturn();
            try
            {
                var shop = await _service.GetAsync(name);
                if (shop == null) { return NotFound(); }
                updatedShop.Name = shop.Name;
                await _service.UpdateAsync(name, updatedShop);
                okReturn.Status = Response.StatusCode;
                return Ok(okReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            var okReturn = new statusReturn();
            try
            {
                var shop = await _service.GetAsync(name);
                if (shop == null) { return NotFound(); }
                await _service.DeleteAsync(name);
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
