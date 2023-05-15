using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;

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

        [HttpPost("registration")]
        public async Task<ActionResult<User>> Post(User newUser)
        {
            registerData data = new registerData();
            var regex1 = new Regex(@"([a-zA-Z])");
            var regex2 = new Regex(@"([0 - 9])");
            //var regex3 = new Regex(@"([!,@,#,$,%,^,&,*,?,_,~])");
            string[] allowableEmail = { ".com", ".net", ".ua" };

            try
            {
                if(newUser.Pass.Length < 8 || !regex1.IsMatch(newUser.Pass) || !regex2.IsMatch(newUser.Pass)) 
                {
                    data.Status = 400;
                    data.Pass = "Your password is too easy";
                }
                if (newUser.Phone.ToString().Length != 12)
                {
                    data.Status = 400;
                    data.Phone = "Incorrect phone number";
                }
                if (!newUser.Email.Contains("@") || !allowableEmail.Any(x => newUser.Email.EndsWith(x)))
                {
                    data.Status = 400;
                    data.Email = "Incorrect Email";
                }
                if(data.Status != 200) 
                {
                    return BadRequest(Response.WriteAsJsonAsync(data));
                }

                var user = await _service.GetEmailAsync(newUser.Email);
                if (user == null)
                {
                    await _service.CreateAsync(newUser);
                    return CreatedAtRoute("GetUserById", new { id = newUser.Id }, newUser);
                }

                return BadRequest("this email is already registered");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLogin loginData)
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
                    loginData data = new loginData();

                    data.Status = Response.StatusCode;
                    data.Id = user.Id;
                    data.Name = user.Name;
                    data.Token = _service.TokenCreate(user);

                    return Ok(Response.WriteAsJsonAsync(data));
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

        [HttpPost("login/test")]
        public ActionResult Test(jwt token)
        {
            try
            {
                if (_service.ValidateToken(token.Token)) 
                {
                    return Ok(true);
                }
                else { return Unauthorized(); }
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}