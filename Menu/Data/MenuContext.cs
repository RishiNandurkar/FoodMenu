using Menu.Models;
using Microsoft.EntityFrameworkCore;

namespace Menu.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options) :base(options) 
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredient>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });

            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(i => i.Ingredient).WithMany(di => di.DishIngredients).HasForeignKey(i =>i.IngredientId);

            modelBuilder.Entity<Dish>().HasData(
                new Dish { Id = 1, Name= "Margheritta", Price = 7.50, ImageUrl= "https://www.nourish-and-fete.com/wp-content/uploads/2017/03/homemade-margherita-pizza-4.jpg" }
                
                );

            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Tomatto Sause"},
                new Ingredient { Id = 2, Name = " Mozerolla" }
                );

            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient { DishId = 1, IngredientId = 1 },
                new DishIngredient { DishId = 1, IngredientId = 2}
                );

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<DishIngredient> DishIngredients { get; set; }
    }
}
