using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Ingredients;

namespace FoodRecipes.Application.Abstractions.Repositories;

public interface IIngredientRepository : IRepository<Ingredient>
{
    Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken);

    Task<List<Ingredient>> GetAll(CancellationToken cancellationToken);

    Task<List<Ingredient>> SearchByName(string name, CancellationToken cancellationToken);

    Task<bool> NameExists(string name, CancellationToken cancellationToken);

    void Delete(Ingredient ingredient);

    void Insert(Ingredient ingredient);

    void Update(Ingredient ingredient);
}
