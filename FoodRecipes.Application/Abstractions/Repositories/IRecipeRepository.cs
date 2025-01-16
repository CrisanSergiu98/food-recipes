using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Interface for accessing and managing recipes
public interface IRecipeRepository : IRepository<Recipe>
{
    // Retrieves a recipe by its ID
    Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default);

    // Retrieves all recipes
    Task<List<Recipe>> GetAll(CancellationToken cancellationToken = default);

    // Searches for recipes by title
    Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken);

    // Checks if a recipe title already exists
    Task<bool> TitleExists(string title, CancellationToken cancellationToken);

    // Updates an existing recipe
    void Update(Recipe recipe);

    // Deletes a recipe
    void Delete(Recipe recipe);

    // Inserts a new recipe
    void Insert(Recipe recipe);
}
