using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Housing.Models;

namespace Housing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Furniture> Furniture { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<DeliveryContact> DeliveryContacts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Set decimal precision for Price in Furniture
            modelBuilder.Entity<Furniture>()
                .Property(f => f.Price)
                .HasPrecision(18, 2);

            // Optional: Add additional precision rules for other models here if needed
        }
    }
}
