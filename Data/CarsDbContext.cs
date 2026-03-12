using Car.Models;
using Microsoft.EntityFrameworkCore;

namespace Car.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext(DbContextOptions<CarsDbContext> options) : base(options)
        {
        }
        public DbSet<Cars> cars { get; set; }
    }
}
