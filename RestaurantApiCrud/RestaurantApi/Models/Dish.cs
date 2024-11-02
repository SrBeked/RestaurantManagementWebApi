using System.Collections.Generic;

namespace RestaurantApi.Models
{
    public class Dish
    {
        public int DishId { get; set; }       
        public required string Name { get; set; }       
        public string? Description { get; set; } 
        public decimal Price { get; set; }    
    }
}
