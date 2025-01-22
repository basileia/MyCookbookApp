using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Models;

namespace MyCookbook.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Sn�dan�" },
                new Category { Id = 2, Name = "Ob�d" },
                new Category { Id = 3, Name = "Ve�e�e" },
                new Category { Id = 4, Name = "Sva�ina" }
            );
        }
    }
}
