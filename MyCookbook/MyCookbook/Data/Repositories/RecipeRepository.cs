using Microsoft.EntityFrameworkCore;
using MyCookbook.Data.Contracts.Repositories;
using MyCookbook.Data.Models;
using MyCookbook.Shared.DTOs;

namespace MyCookbook.Data.Repositories
{
    public class RecipeRepository : BaseRepository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Recipe?> GetByIdWithDetailsAsync(int id)
        {
            var recipe = await _context.Recipes
                .Include(r => r.Categories)
                .Include(r => r.Ingredients)
                .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.Steps)       
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (recipe != null)
            {
                recipe.Steps = recipe.Steps.OrderBy(s => s.StepNumber).ToList();
            }

            return recipe;
        }

        public async Task<Recipe?> GetByNameAsync(string name)
        {
            return await _context.Recipes
                .Include(r => r.Categories)
                .FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
        }

        public async Task<List<Recipe?>> GetFilteredAsync(FilterCriteriaDto filter, string userId)
        {
            var query = _context.Recipes
                .Include(r => r.Categories)
                .OrderBy(r => r.Name)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.SearchText))
            {
                var text = filter.SearchText;
                var pattern = $"%{text}%";

                query = query.Where(r =>
                    EF.Functions.ILike(
                        EF.Functions.Unaccent(r.Name),
                        EF.Functions.Unaccent(pattern)
                    ));
            }

            if (!string.IsNullOrWhiteSpace(filter.Ingredient))
            {
                var text = filter.Ingredient;
                var pattern = $"%{text}%";

                query = query.Where(r => r.Ingredients.Any(ri =>
                    EF.Functions.ILike(
                        EF.Functions.Unaccent(ri.Ingredient.NormalizedName ?? ri.Ingredient.Name),
                        EF.Functions.Unaccent(pattern)
                    )));
            }

            if (!string.IsNullOrEmpty(userId))
            {
                if (filter.Favorites == true)
                    query = query.Where(r => _context.UserRecipeStatuses
                        .Any(urs => urs.RecipeId == r.Id && urs.UserId == userId && urs.IsFavourite));

                if (filter.Tried == true)
                    query = query.Where(r => _context.UserRecipeStatuses
                        .Any(urs => urs.RecipeId == r.Id && urs.UserId == userId && urs.IsTried));

                if (filter.Mine == true)
                    query = query.Where(r => r.UserId == userId);
            }

            return await query.ToListAsync();
        }
    }
}
