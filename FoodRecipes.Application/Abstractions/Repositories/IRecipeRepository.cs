using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Repository interface for managing Recipe entities
public interface IRecipeRepository : IRepository<Recipe>
{
    // Get a recipe by its ID
    Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default);

    // Get all recipes
    Task<List<Recipe>> GetAll(CancellationToken cancellationToken = default);
    
    Task<bool> TitleExists(string title, CancellationToken cancellationToken);

    // Update an existing recipe
    void Update(Recipe recipe);

    // Delete a recipe by its ID
    void Delete(Recipe recipe);

    // Insert a new recipe
    void Insert(Recipe recipe);
}
