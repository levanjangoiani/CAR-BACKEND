using Car.Models;
using Car.Repository.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Car.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarsService _carsService;

        public CarsController(ICarsService carsService)
        {
            _carsService = carsService;
        }
        [HttpGet("brand")]
        public async Task<IActionResult> GetCarsByBrand(string brand)
        {
            var cars = await _carsService.GetCarsByBrandAsycn(brand);
            return Ok(cars);
        }
        [HttpGet("model")]
        public async Task<IActionResult> GetCarsByModel(string model)
        {
            var cars = await _carsService.GetCarsByModelAsycn(model);
            return Ok(cars);
        }
        [HttpGet("year")]
        public async Task<IActionResult> GetCarsByYear(int year)
        {
            var cars = await _carsService.GetCarsByYearAsycn(year);
            return Ok(cars);
        }
        [HttpGet("color")]
        public async Task<IActionResult> GetCarsByColor(string color)
        {
            var cars = await _carsService.GetCarsByColorAsycn(color);
            return Ok(cars);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var car = await _carsService.GetCarByIdAsycn(id);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }
        [HttpGet("cars")]
        public async Task<IActionResult> GetAllCars()
        {
            var cars = await _carsService.GetAllCarsAsycn();
            return Ok(cars);
        }
        [HttpPost("addCar")]
        public async Task<IActionResult> AddCar(Cars car)
        {
            var addedCar = await _carsService.AddCarAsycn(car);
            return CreatedAtAction(nameof(GetCarById), new { id = addedCar.Id }, addedCar);
        }
        [HttpPut("updateCar/{id}")]
        public async Task<IActionResult> UpdateCar(int id, Cars car)
        {
            var updatedCar = await _carsService.UpdateCarAsycn(id, car);
            if (updatedCar == null)
            {
                return NotFound();
            }
            return Ok(updatedCar);
        }
        [HttpDelete("deleteCar/{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var deleted = await _carsService.DeleteCarAsycn(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
