using CarSharingAPI.Data;
using CarSharingAPI.Migrations;
using CarSharingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CarSharingAPIDbContext _context;
        public UserController(CarSharingAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUserList()
        {
            var users = await _context.Users
                .ToListAsync();
            return users;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDTO userDTO)
        {
            var user = new User()
            {
                UserName = userDTO.UserName,
                FullName = userDTO.FullName,
                Password = userDTO.Password,
                PhoneNumber = userDTO.PhoneNumber
            };
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateUser([FromRoute] int id, UserDTO userDTO)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.UserName = userDTO.UserName;
                user.Password = userDTO.Password;
                user.FullName = userDTO.FullName;
                user.PhoneNumber = userDTO.PhoneNumber;

                await _context.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return Ok(user);
            }
            return NotFound();
        }
    }
}
