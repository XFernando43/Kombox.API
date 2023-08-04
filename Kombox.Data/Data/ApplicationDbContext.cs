using Kombox.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Kombox.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { 
            
        }

            public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "HOME" },
                new Category { CategoryId = 2, Name = "BITCH" }
                );
        }
    }
}
