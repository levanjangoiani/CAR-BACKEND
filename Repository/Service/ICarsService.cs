using Car.Models;

namespace Car.Repository.Service
{
    public interface ICarsService
    {
        Task<List<Cars>> GetAllCarsAsycn();
        Task<Cars> GetCarByIdAsycn(int id);
        Task<Cars> AddCarAsycn(Cars car);
        Task<Cars> UpdateCarAsycn(int id, Cars car);
        Task<bool> DeleteCarAsycn(int id);
        Task<List<Cars>> GetCarsByBrandAsycn(string brand);
         Task<List<Cars>> GetCarsByYearAsycn(int year);
        Task<List<Cars>> GetCarsByColorAsycn(string color);
        Task<List<Cars>> GetCarsByModelAsycn(string model);
    }
}
