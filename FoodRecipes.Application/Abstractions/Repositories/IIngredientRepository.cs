using FoodRecipes.Application.Abstractions.Data;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodRecipes.Application.Abstractions.Repositories
{
    public interface IIngredientRepository: IRepository<Ingredient>
    {
        Task<Ingredient?> GetById(Guid id, CancellationToken cancellationToken);
        Result Delete(Guid id);
        Result Insert(Ingredient ingredient);
        Result Update(Ingredient ingredient);
    }
}
