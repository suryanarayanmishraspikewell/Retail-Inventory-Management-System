//namespace InventoryManagementAPI.Models
//{
//    public class AppDbContext
//    {
//    }
//}


using InventoryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace InventoryManagementAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User-Order Relationship (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasOne<User>() // Order has one User
                .WithMany() // User has many Orders
                .HasForeignKey(o => o.UserId) // Foreign Key in Order table
                .OnDelete(DeleteBehavior.Cascade); // If a User is deleted, their orders are deleted

            // Product-Order Relationship (One-to-Many)
            modelBuilder.Entity<Order>()
                .HasOne<Product>() // Order has one Product
                .WithMany() // Product can have many Orders
                .HasForeignKey(o => o.ProductId) // Foreign Key in Order table
                .OnDelete(DeleteBehavior.Restrict); // Prevent deletion if there are related orders
        }
    }
}
