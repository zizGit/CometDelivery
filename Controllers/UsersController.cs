using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;

namespace CometFoodDelivery.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _service;

        public UsersController(UsersService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return await _service.GetAsync();
        }

        [HttpGet("{id:length(24)}", Name = "GetUserById")]
        public async Task<ActionResult<User>> Get(string id)
        {
            try
            {
                var user = await _service.GetAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("email/{email}", Name = "GetUserByEmail")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            try
            {
                var user = await _service.GetEmailAsync(email);
                if (user == null)
                {
                    return NotFound();
                }
                return user;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User newUser)
        {
            try
            {
                await _service.CreateAsync(newUser);
                return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserLogin>> Login(UserLogin loginData)
        {
            try
            {
                var user = await _service.GetEmailAsync(loginData.Email);
                if (user == null)
                {
                    return NotFound();
                }

                if (user.Email == loginData.Email && user.Pass == loginData.Pass) 
                {
                    return Ok(Response.StatusCode);
                }
                else 
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            try
            {
                var user = await _service.GetAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                updatedUser.Id = user.Id;
                await _service.UpdateAsync(id, updatedUser);

                return Ok(Response.StatusCode);
                //return NoContent();
                //return CreatedAtRoute("GetById", new { id = updatedUser.Id }, updatedUser);
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
                var user = await _service.GetAsync(id);
                if (user == null)
                {
                    return NotFound();
                }

                await _service.DeleteAsync(id);
                return Ok(Response.StatusCode);
                //return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}