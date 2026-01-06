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
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }
        public DbSet<MealPlanDay> MealPlanDays { get; set; }
        public DbSet<MealPlanRecipe> MealPlanRecipes { get; set; }

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

            modelBuilder.Entity<RecipeStep>()
            .HasOne(rs => rs.Recipe)
            .WithMany(r => r.Steps)
            .HasForeignKey(rs => rs.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealPlanRecipe>()
            .HasKey(x => new { x.MealPlanDayId, x.RecipeId });

            modelBuilder.Entity<MealPlan>()
            .HasOne(mp => mp.User)
            .WithMany() 
            .HasForeignKey(mp => mp.UserId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealPlanDay>()
            .HasOne(d => d.MealPlan)
            .WithMany(mp => mp.DaysPlan)
            .HasForeignKey(d => d.MealPlanId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealPlanRecipe>()
            .HasOne(mpr => mpr.MealPlanDay)
            .WithMany(d => d.Recipes)
            .HasForeignKey(mpr => mpr.MealPlanDayId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MealPlanRecipe>()
            .HasOne(mpr => mpr.Recipe)
            .WithMany()
            .HasForeignKey(mpr => mpr.RecipeId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
