using IceCreamProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IceCreamParlour.Models
{
    public class paymentsDBContext : DbContext
    {
        public paymentsDBContext(DbContextOptions<paymentsDBContext> options) : base(options)
        {
        }

        public DbSet<Payments> Payments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration here
        }
    }
}