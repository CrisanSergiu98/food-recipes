using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Interface for accessing and managing recipes
public interface IRecipeRepository : IRepository<Recipe>
{
    // Retrieves a recipe by its ID
        Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken);

        // Retrieves all recipes
        Task<List<Recipe>> GetAll(CancellationToken cancellationToken);

        // Searches for recipes by title (case-insensitive)
        Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken);

        // Checks if a recipe title already exists
        Task<bool> TitleExists(string title, CancellationToken cancellationToken);

        // Inserts a new recipe
        Task Insert(Recipe recipe, CancellationToken cancellationToken);

        // Updates an existing recipe
        Task Update(Recipe recipe, CancellationToken cancellationToken);

        // Deletes a recipe
        Task Delete(Recipe recipe, CancellationToken cancellationToken);
}
