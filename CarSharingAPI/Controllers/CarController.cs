using CarSharingAPI.Data;
using CarSharingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly CarSharingAPIDbContext _context;
        public CarController(CarSharingAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetCarList(int userId)
        {
            var cars = await _context.Cars
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return cars;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(CarDTO carDTO)
        {
            var user = _context.Users.Find(carDTO.OwnerID);
            if(user == null)
            {
                return NotFound();
            }
            var car = new Car()
            {
                Plate = carDTO.Plate,
                Brand = carDTO.Brand,
                Model = carDTO.Model,
                UserId = carDTO.OwnerID       
            };

            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return Ok(car);
        }

        [HttpDelete]
        [Route("{plate}")]
        public async Task<IActionResult> DeleteCar([FromRoute] string plate)
        {
            var car = await _context.Cars.FindAsync(plate);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
                return Ok(car);
            }
            return NotFound();
        }
    }
}
