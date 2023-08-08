using Kombox.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Kombox.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RolUser> RolUsers { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

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

            modelBuilder.Entity<RolUser>().HasData(
                new RolUser { RolId = 1, RolName = "Admin", Access = "All" },
                new RolUser { RolId = 2, RolName = "Employee", Access = "lower" },
                new RolUser { RolId = 3, RolName = "Client", Access = "public" }
                );
        }
    }
}
