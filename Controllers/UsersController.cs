//using InventoryManagementAPI.Models;
//using InventoryManagementAPI.Repositories;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace InventoryManagementAPI.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class UsersController : ControllerBase
//    {
//    }
//}

using InventoryManagementAPI.Models;
using InventoryManagementAPI.Repositories;
using InventoryManagementAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUserService _userServcie;
        private object user;

        public UsersController(IRepository<User> userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userServcie = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            //return Ok(await _userRepository.GetAll());
            return Ok(await _userServcie.GetAllUsers());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            //var user = await _userRepository.GetById(id);
            var user = await _userServcie.GetUserByID(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(User user)
        {
            //await _userRepository.Add(user);
            await _userServcie.Createuser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.UserId) return BadRequest();
            //await _userRepository.Update(user);
            await _userServcie.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userServcie.DeleteUser(id);
            return NoContent();
        }
    }
}
