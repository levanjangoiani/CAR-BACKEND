using Car.Data;
using Car.Models;
using Car.Repository.Service;
using Microsoft.EntityFrameworkCore;

namespace Car.Repository.Implementation
{
    public class CarRepository : ICarsService
    {
        private readonly CarsDbContext _context;

        public CarRepository(CarsDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cars>> GetCarsByBrandAsycn(string brand)
        {
            return await _context.cars.Where(c => c.brand == brand).ToListAsync();
        }
        public async Task<List<Cars>> GetCarsByModelAsycn(string model)
        {
            return await _context.cars.Where(c => c.Model == model).ToListAsync();
        }
        public async Task<List<Cars>> GetCarsByYearAsycn(int year)
        {
            return await _context.cars.Where(c => c.Year == year).ToListAsync();
        }
        public async Task<List<Cars>> GetCarsByColorAsycn(string color)
        {
            return await _context.cars.Where(c => c.Color == color).ToListAsync();
        }
        public async Task<Cars> GetCarByIdAsycn(int id)
        {
            return await _context.cars.FindAsync(id);
        }
        public async Task<List<Cars>> GetAllCarsAsycn()
        {
            return await _context.cars.ToListAsync();
        }
        public async Task<Cars> AddCarAsycn(Cars car)
        {
            _context.cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }
        public async Task<Cars> UpdateCarAsycn(int id, Cars car)
        {
            var existingCar = await _context.cars.FindAsync(id);
            if (existingCar == null)
            {
                return null;
            }
            existingCar.brand = car.brand;
            existingCar.Model = car.Model;
            existingCar.Year = car.Year;
            existingCar.Color = car.Color;
            existingCar.ImageUrl = car.ImageUrl;
            await _context.SaveChangesAsync();
            return existingCar;
        }
        public async Task<bool> DeleteCarAsycn(int id)
        {
            var car = await _context.cars.FindAsync(id);
            if (car == null)
            {
                return false;
            }
            _context.cars.Remove(car);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
