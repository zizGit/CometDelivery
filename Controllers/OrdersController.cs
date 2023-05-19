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

        //[HttpPost("registration")]
        //public async Task<ActionResult<User>> Post(User newUser)
        //{
        //    var data = new registerData();
        //    var emailError = new errorReturn();
        //    try
        //    {
        //        if (!_service.registrationAndUpdateRules(newUser, ref data))
        //        {
        //            var responce = new registerErrorReturn { Errors = data };
        //            await Response.WriteAsJsonAsync(responce);
        //            return BadRequest(responce);
        //        }

        //        var user = await _service.GetAsync(null, newUser.Email);
        //        if (user == null)
        //        {
        //            await _service.CreateAsync(newUser);
        //            return CreatedAtRoute("GetUser", new { id = newUser.Id }, _service.returnWith200(newUser));
        //        }

        //        emailError.Error = "this email is already registered";
        //        await Response.WriteAsJsonAsync(emailError);
        //        return BadRequest(emailError);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost("login")]
        //public async Task<ActionResult> Login(UserLogin loginData)
        //{
        //    var okReturn = new statusReturn();
        //    try
        //    {
        //        if (loginData.Token != null)
        //        {
        //            if (_service.ValidateToken(loginData.Token))
        //            {
        //                okReturn.Status = Response.StatusCode;
        //                return Ok(okReturn);
        //            }
        //            else { return Unauthorized(); }
        //        }
        //        else if (loginData.Email != null && loginData.Pass != null)
        //        {
        //            var user = await _service.GetAsync(null, loginData.Email);
        //            if (user == null) { return NotFound(); }

        //            if (user.Email == loginData.Email && user.Pass == loginData.Pass)
        //            {
        //                loginData data = new loginData();

        //                data.Id = user.Id;
        //                data.Name = user.Name;
        //                data.Token = _service.TokenCreate(user.Email);

        //                await Response.WriteAsJsonAsync(data);
        //                return Ok(data);
        //            }
        //        }
        //        return BadRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

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
