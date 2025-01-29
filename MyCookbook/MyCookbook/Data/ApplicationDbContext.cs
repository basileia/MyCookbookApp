using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Models;

namespace MyCookbook.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<UserRecipeStatus> UserRecipeStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Snídanì" },
                new Category { Id = 2, Name = "Obìd" },
                new Category { Id = 3, Name = "Veèeøe" },
                new Category { Id = 4, Name = "Svaèina" }
            );

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User) 
                .WithMany()  
                .HasForeignKey(r => r.UserId) 
                .OnDelete(DeleteBehavior.Restrict);  

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });
            
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany()
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<UserRecipeStatus>()
                .HasKey(urs => new { urs.UserId, urs.RecipeId });

            modelBuilder.Entity<UserRecipeStatus>()
                .HasOne(urs => urs.User)
                .WithMany()
                .HasForeignKey(urs => urs.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRecipeStatus>()
                .HasOne(urs => urs.Recipe)
                .WithMany()
                .HasForeignKey(urs => urs.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
