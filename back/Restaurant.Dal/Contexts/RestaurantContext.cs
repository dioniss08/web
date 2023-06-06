using Microsoft.EntityFrameworkCore;
using Restaurant.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Dal.Contexts
{
    public class RestaurantContext : DbContext
    {
        public DbSet<Dish> Dishes { get; set; } = null!;
        public DbSet<Drink> Drinks { get; set; } = null!;
        public DbSet<MenuPosition> MenuPositions { get; set; } = null!;

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RestaurantContext).Assembly);
            //InitialDataBase.InitialRestaurant(modelBuilder);
        }
    }

}
