using Kombox.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Kombox.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
            
        }

            public DbSet<Category> Categories { get; set; }
            public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Jelwey" },
                new Category { CategoryId = 2, Name = "Gaming" }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Collar", Description = "Collar de Fenix", Price = 100, CategoryId = 1 },
                new Product { ProductId = 2, Name = "Brazalate", Description = "Brazalete de Thanos", Price = 100, CategoryId = 1 },
                new Product { ProductId = 3, Name = "Anillo", Description = "Anillo del Inifinito", Price = 100, CategoryId = 1 }
                );
        }
    }
}
