using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Application.Abstractions.Repositories;

// Interface for accessing and managing ingredients
public interface IIngredientRepository: IRepository<Ingredient>
    {
        // Retrieves an ingredient by its ID
        Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken);

        // Retrieves all ingredients
        Task<List<Ingredient>> GetAll(CancellationToken cancellationToken);

        // Searches for ingredients by name
        Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken);

        // Checks if an ingredient name already exists
        Task<bool> NameExists(string name, CancellationToken cancellationToken);

        // Inserts a new ingredient
        Task Insert(Ingredient ingredient, CancellationToken cancellationToken);

        // Updates an existing ingredient
        Task Update(Ingredient ingredient, CancellationToken cancellationToken);

    // Deletes an ingredient
    Task Delete(Ingredient ingredient, CancellationToken cancellationToken);
}