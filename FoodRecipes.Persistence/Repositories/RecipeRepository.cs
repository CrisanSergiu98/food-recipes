using FoodRecipes.Domain.Recipes;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Persistence.Repositories
{
public class RecipeRepository: IRecipeRepository
    {
        private readonly List<Recipe> _recipes = new();

        public Result Delete(Guid id)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return Result.Failure(new Error("", "Recipe not found."));
            }

            _recipes.Remove(recipe);
            return Result.Success();
        }

        public Result<IEnumerable<Recipe>> GetAll(CancellationToken cancellationToken = default)
        {
            return Result.Success(_recipes.AsEnumerable());
        }

        public Result<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var recipe = _recipes.FirstOrDefault(r => r.Id == id);
            if (recipe == null)
            {
                return Result.Failure<Recipe?>(new Error("", "Recipe not found."));
            }

            return Result.Success(recipe);
        }

        public Result Insert(Recipe recipe)
        {
            if (_recipes.Any(r => r.Id == recipe.Id))
            {
                return Result.Failure(new Error("", "Recipe already exists."));
            }

            _recipes.Add(recipe);
            return Result.Success();
        }

        public Result Update(Recipe recipe)
        {
            var existingRecipe = _recipes.FirstOrDefault(r => r.Id == recipe.Id);
            if (existingRecipe == null)
            {
                return Result.Failure(new Error("", "Recipe not found."));
            }

            _recipes.Remove(existingRecipe);
            _recipes.Add(recipe);
            return Result.Success();
        }
    }
}
