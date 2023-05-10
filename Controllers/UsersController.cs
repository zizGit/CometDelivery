using CometFoodDelivery.Models;
using CometFoodDelivery.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpGet("{id:length(24)}", Name = "GetById")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _service.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post(User newUser)
        {
            await _service.CreateAsync(newUser);
            return CreatedAtRoute("GetById", new { id = newUser.Id }, newUser);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _service.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;
            await _service.UpdateAsync(id, updatedUser);
            return NoContent();
            //return CreatedAtRoute("GetById", new { id = updatedUser.Id }, updatedUser);

        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _service.GetAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}