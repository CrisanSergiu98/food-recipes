using FoodRecipes.Domain.Primitives;

namespace FoodRecipes.Application.Abstractions.Data;

public interface IRepository<in T>
    where T : AggregateRoot
{
}
