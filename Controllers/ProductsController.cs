using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace CometFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/shops/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductsController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            return await _service.GetAsync();
        }

        [HttpGet("{type}", Name = "GetProductByType")]
        public async Task<ActionResult<Product>> Get(string type)
        {
            try
            {
                var product = await _service.GetAsync(type);
                if (product == null)
                {
                    return NotFound();
                }
                return product;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Product>> Post(Product newProduct)
        {
            try
            {
                await _service.CreateAsync(newProduct);
                return CreatedAtRoute("GetProductByType", new { type = newProduct.Type }, newProduct);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpPut("{name}")]
        //public async Task<IActionResult> Update(string name, Shop updatedShop)
        //{
        //    try
        //    {
        //        var shop = await _service.GetAsync(name);
        //        if (shop == null)
        //        {
        //            return NotFound();
        //        }

        //        updatedShop.Name = shop.Name;
        //        await _service.UpdateAsync(name, updatedShop);

        //        return Ok($"StatusCode {Response.StatusCode}");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpDelete("{type}")]
        public async Task<IActionResult> Delete(string type)
        {
            try
            {
                var product = await _service.GetAsync(type);
                if (product == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(type);
                return Ok($"StatusCode {Response.StatusCode}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{type}/{name}")]
        public async Task<IActionResult> Delete(string type, string name)
        {
            try
            {
                var product = await _service.GetAsync(name);
                if (product == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(name);
                return Ok($"StatusCode {Response.StatusCode}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
