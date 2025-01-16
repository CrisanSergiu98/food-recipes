using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Persistence.Repositories
{
    // Repository class for managing recipes
    public class RecipeRepository : IRecipeRepository
    {
        private readonly List<Recipe> _recipes = new();

        // Retrieves a recipe by its ID
        public Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            return Task.FromResult(recipe);
        }

        // Retrieves all recipes
        public Task<List<Recipe>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_recipes.ToList());
        }

        // Searches for recipes by title
        public Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken)
        {
            var matchingRecipes = _recipes
                .Where(r => r.Title.Value.Contains(title, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Task.FromResult(matchingRecipes);
        }

        // Inserts a new recipe
        public void Insert(Recipe recipe)
        {
            _recipes.Add(recipe);
        }

        // Updates an existing recipe
        public void Update(Recipe recipe)
        {
            var existingRecipe = _recipes.FirstOrDefault(r => r.Id == recipe.Id);
            if (existingRecipe != null)
            {
                _recipes.Remove(existingRecipe);
                _recipes.Add(recipe);
            }
        }

        // Deletes a recipe
        public void Delete(Recipe recipe)
        {
            _recipes.Remove(recipe);
        }

        // Checks if a recipe title already exists
        public async Task<bool> TitleExists(string title, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_recipes.Any(recipe => recipe.Title.Value == title));
        }
    }
}
