using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Persistence.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {        
        private readonly List<Ingredient> _ingredients = DemoData.GetDemoIngredients();

        public Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken)
        {
            var ingredient = _ingredients.FirstOrDefault(i => i.Id == id);
            return Task.FromResult(ingredient);
        }

        public Task<List<Ingredient>> GetAll(CancellationToken cancellationToken)
        {
            return Task.FromResult(_ingredients.ToList());
        }

        public Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken)
        {
            var matchingIngredients = _ingredients
                .Where(i => i.Name.Value.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList(); 
            
            return Task.FromResult(matchingIngredients);
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

        public void Delete(Ingredient ingredient)
        {
            _ingredients.Remove(ingredient);
        }

        public async Task<bool> NameExists(string name, CancellationToken cancellationToken)
        {             
            return await Task.FromResult(_ingredients.Any(ingredient => ingredient.Name.Value == name));
        }
    }
}
