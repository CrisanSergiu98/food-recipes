using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Persistence.Repositories
{
    // Repository class for managing ingredients
    public class IngredientRepository : IIngredientRepository
    {
        //private readonly List<Ingredient> _ingredients = DemoData.GetDemoIngredients();
        private readonly List<Ingredient> _ingredients = new List<Ingredient>();

        // Retrieves an ingredient by its ID
        public Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(ingredient);
        }

        // Retrieves all ingredients
        public Task<List<Ingredient>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_ingredients.ToList());
        }

        // Searches for ingredients by name
        public Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken)
        {
            var matchingIngredients = _ingredients
                .Where(i => i.Name.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Task.FromResult(matchingIngredients);
        }

        // Inserts a new ingredient
        public void Insert(Ingredient ingredient)
        {
            _ingredients.Add(ingredient);
        }

        // Updates an existing ingredient
        public void Update(Ingredient ingredient)
        {
            var existingIngredient = _ingredients.FirstOrDefault(i => i.Id == ingredient.Id);
            if (existingIngredient != null)
            {
                _ingredients.Remove(existingIngredient);
                _ingredients.Add(ingredient);
            }
        }

        // Deletes an ingredient
        public void Delete(Ingredient ingredient)
        {
            _ingredients.Remove(ingredient);
        }

        // Checks if an ingredient name already exists
        public async Task<bool> NameExists(string name, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_ingredients.Any(ingredient => ingredient.Name.Value == name));
        }
    }
}
