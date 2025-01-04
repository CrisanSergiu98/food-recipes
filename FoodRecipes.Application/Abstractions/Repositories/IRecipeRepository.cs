using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Repository interface for managing Recipe entities
public interface IRecipeRepository : IRepository<Recipe>
{
    // Get a recipe by its ID
    Result<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default);

    // Get all recipes
    Result<IEnumerable<Recipe>> GetAll(CancellationToken cancellationToken = default);

    // Update an existing recipe
    Result Update(Recipe recipe);

    // Delete a recipe by its ID
    Result Delete(Guid id);

    // Insert a new recipe
    Result Insert(Recipe recipe);
}
