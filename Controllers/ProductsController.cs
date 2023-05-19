using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace CometFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpGet("{shop}", Name = "GetProductByShop")]
        public async Task<ActionResult<List<Product>>> GetByShop(string shop)
        {
            try
            {
                var product = await _service.GetByShopAsync(shop);
                if (product == null) { return NotFound(); }
                return product;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{shop}/{section}")]
        public async Task<ActionResult<List<Product>>> GetByShopAndSection(string shop)
        {
            try
            {
                var product = await _service.GetByShopAsync(shop);
                if (product == null) { return NotFound(); }
                return product;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<List<Product>>> Get(ProductShopAndType data)
        {
            try
            {
                if (data.Shop != null) 
                {
                    var product = await _service.GetByShopAsync(data.Shop);
                    if (product == null) { return NotFound(); }
                    return await _service.GetByShopAndTypeAsync(data.Shop, data.Type);
                }
                else
                {
                    var product = await _service.GetByTypeAsync(data.Type);
                    if (product == null) { return NotFound(); }
                    return await _service.GetByTypeAsync(data.Type);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("new")]
        public async Task<ActionResult<Product>> Post(Product newProduct)
        {
            var productError = new errorProductReturn();
            try
            {
                var product = await _service.GetByShopTypeNameAsync(newProduct.Shop, newProduct.Type, newProduct.Name);
                if (product == null)
                {
                    await _service.CreateAsync(newProduct);
                    return CreatedAtRoute("GetProductByShop", new { shop = newProduct.Shop }, newProduct);
                }
                await Response.WriteAsJsonAsync(productError);
                return BadRequest(productError);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Product updatedProduct)
        {
            var okReturn = new statusReturn();
            try
            {
                var product = await _service.GetByIdAsync(id);
                if (product == null) { return NotFound(); }
                updatedProduct.Id = id;
                await _service.UpdateAsync(id, updatedProduct);
                okReturn.Status = Response.StatusCode;
                return Ok(okReturn);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var okReturn = new statusReturn();
            try
            {
                var product = await _service.GetByIdAsync(id);
                if (product == null) { return NotFound(); }
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
