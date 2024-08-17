using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IRecipeRepository:IRepository<Recipe>
{
    Result<Recipe?> GetById(Guid id, CancellationToken cancellationToken= default);
    Result<IEnumerable<Recipe>> GetAll(CancellationToken cancellationToken = default);
    Result Update(Recipe recipe);
    Result Delete(Guid id);
    Result Insert(Recipe recipe);
}
