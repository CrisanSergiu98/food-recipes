using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Persistence.Repositories
{
public class IngredientRepository: IIngredientRepository
    {
        private readonly List<Ingredient> _ingredients = new();

        public Result Delete(Guid id)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient == null)
            {
                return Result.Failure(new Error("", "Ingredient not found."));
            }

            _ingredients.Remove(ingredient);
            return Result.Success();
        }

        public Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(ingredient);
        }

        public Result Insert(Ingredient ingredient)
        {
            if (_ingredients.Any(i => i.Id == ingredient.Id))
            {
                return Result.Failure(new Error("", "Ingredient already exists."));
            }

            _ingredients.Add(ingredient);
            return Result.Success();
        }

        public Result Update(Ingredient ingredient)
        {
            var existingIngredient = _ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
            if (existingIngredient == null)
            {
                return Result.Failure(new Error("", "Ingredient not found."));
            }
            
            _ingredients.Remove(existingIngredient);
            _ingredients.Add(ingredient);

            return Result.Success();
        }
    }
}
