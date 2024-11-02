using Microsoft.EntityFrameworkCore;
using RestaurantApi.Models;
namespace RestaurantApi.Data
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options) { }

        public DbSet<Dish> Dishes { get; set; } 
    }
}
