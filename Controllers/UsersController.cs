using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public async Task<ActionResult<List<string>>> Login(UserLogin loginData)
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
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.Name) };
                    // создаем JWT-токен
                    var jwt = new JwtSecurityToken(
                            issuer: AuthOptions.ISSUER,
                            audience: AuthOptions.AUDIENCE,
                            claims: claims,
                            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                    List<string> responce = new List<string>();
                    responce.Add(Response.StatusCode.ToString());
                    responce.Add(new JwtSecurityTokenHandler().WriteToken(jwt));

                    return responce;
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