using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Repository interface for managing Ingredient entities
public interface IIngredientRepository : IRepository<Ingredient>
{
    // Get an ingredient by its ID
    Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken);

    // Get all ingredients
    Task<List<Ingredient>> GetAll(CancellationToken cancellationToken);

    // Delete an ingredient by its ID
    void Delete(Guid id);

    // Insert a new ingredient
    void Insert(Ingredient ingredient);

    // Update an existing ingredient
    void Update(Ingredient ingredient);
}
