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
                return _service.returnWith200(shop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<List<shopReturn>>> GetSearch(string name)
        {
            try
            {
                var shop = await _service.GetSearchAsync(name);
                if (shop == null) { return NotFound(); }
                return shop;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("type/{type}", Name = "GetShopByType")]
        public async Task<ActionResult<List<Shop>>> GetByType(string type)
        {
            try
            {
                var shop = await _service.GetByTypeAsync(type);
                if (shop == null) { return NotFound(); }
                return shop;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Shop>> Post(Shop newShop)
        {
            var shopError = new errorShopReturn();
            try
            {
                var shop = await _service.GetAsync(newShop.Name);
                if (shop == null)
                {
                    await _service.CreateAsync(newShop);
                    return CreatedAtRoute("GetShopByName", new { name = newShop.Name }, _service.returnWith200(newShop));
                }
                await Response.WriteAsJsonAsync(shopError);
                return BadRequest(shopError);
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
