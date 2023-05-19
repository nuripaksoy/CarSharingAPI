using CarSharingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CarSharingAPI.Data
{
    public class CarSharingAPIDbContext : DbContext
    {
        public CarSharingAPIDbContext(DbContextOptions<CarSharingAPIDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
