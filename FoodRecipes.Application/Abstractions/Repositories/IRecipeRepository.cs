using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IRecipeRepository : IRepository<Recipe>
{
    Task<Recipe?> GetById(Guid id, CancellationToken cancellationToken = default);

    Task<List<Recipe>> GetAll(CancellationToken cancellationToken = default);

    Task<List<Recipe>> SearchByTitle(string title, CancellationToken cancellationToken);

    Task<bool> TitleExists(string title, CancellationToken cancellationToken);

    void Update(Recipe recipe);

    void Delete(Recipe recipe);

    void Insert(Recipe recipe);
}
