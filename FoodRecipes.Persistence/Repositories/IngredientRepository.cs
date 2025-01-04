using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Persistence.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly List<Ingredient> _ingredients = new();

        public Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(ingredient);
        }

        public Task<List<Ingredient>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_ingredients.ToList());
        }

        public void Insert(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        public void Update(Ingredient ingredient)
        {
            var existingIngredient = _ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
            if (existingIngredient != null)
            {
                _ingredients.Remove(existingIngredient);
                _ingredients.Add(ingredient);
            }
        }

        public void Delete(Guid id)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            if (ingredient != null)
            {
                _ingredients.Remove(ingredient);
            }
        }
    }
}
