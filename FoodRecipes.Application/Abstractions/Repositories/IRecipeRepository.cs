using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Recipe>> GetAll(CancellationToken cancellationToken);

    Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken);

    Task<bool> TitleExists(string title, CancellationToken cancellationToken);

    Task Insert(Recipe recipe, CancellationToken cancellationToken);

    Task Update(Recipe recipe, CancellationToken cancellationToken);

    Task Delete(Recipe recipe, CancellationToken cancellationToken);
}
