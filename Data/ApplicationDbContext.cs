using Microsoft.EntityFrameworkCore;
using SupermarketAPI.Model;

namespace SupermarketAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Yoghurts",
                Quantity = 34,
                CostPrice = 250,
                SellingPrice = 360,
                Category = "Yeast"
            },
            new Item()
            {
                Id = Guid.NewGuid(),
                Name = "Peak Milk",
                Quantity = 65,
                CostPrice = 200,
                SellingPrice = 300,
                Category = "Beverages"

            });



        }
    }
}
