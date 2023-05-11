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

        [HttpGet("{id:length(24)}", Name = "GetShopById")]
        public async Task<ActionResult<Shop>> Get(string id)
        {
            try
            {
                var shop = await _service.GetAsync(id);
                if (shop == null)
                {
                    return NotFound();
                }
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
            try
            {
                await _service.CreateAsync(newShop);
                return CreatedAtRoute("GetShopById", new { id = newShop.Id }, newShop);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Shop updatedShop)
        {
            try
            {
                var shop = await _service.GetAsync(id);
                if (shop == null)
                {
                    return NotFound();
                }

                updatedShop.Id = shop.Id;
                await _service.UpdateAsync(id, updatedShop);

                return Ok($"StatusCode {Response.StatusCode}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var shop = await _service.GetAsync(id);
                if (shop == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(id);
                return Ok($"StatusCode {Response.StatusCode}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
