using CoffeShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CoffeShop.Data
{
    public class ShopContext : IdentityDbContext
    {
        public ShopContext(DbContextOptions<ShopContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<SendMessage> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { Id=1,Name="Americano",Detail= "Americanos are popular breakfast drinks and thought to have originated during World War II. Soldiers would add water to their coffee to extend their rations farther. The water dilutes the espresso while still maintaining a high level of caffeine.", ImageUrl= "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_americano.jpg" },
                new Product() { Id = 2, Name = "Espresso", Detail = "The espresso, also known as a short black, is approximately 1 oz. of highly concentrated coffee. Although simple in appearance, it can be difficult to master.", ImageUrl = "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_espresso.jpg" },
                new Product() { Id = 3, Name = "Double Espresso", Detail = "A double espresso may also be listed as doppio, which is the Italian word for double. This drink is highly concentrated and strong.", ImageUrl = "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_double-espresso.jpg" },
                new Product() { Id = 4, Name = "Long Black", Detail = "The long black is a similar coffee drink to the americano, but it originated in New Zealand and Australia. It generally has more crema than an americano.", ImageUrl = "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_long-black.jpg" },
                new Product() { Id = 5, Name = "Macchiato", Detail = "The word macchiato means mark or stain. This is in reference to the mark that steamed milk leaves on the surface of the espresso as it is dashed into the drink. Flavoring syrups are often added to the drink according to customer preference.", ImageUrl = "https://cdnimg.webstaurantstore.com/uploads/blog/2019/4/coffee-drinks_macchiato.jpg" }
                );
        }
    }
}
