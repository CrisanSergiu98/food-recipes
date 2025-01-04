using FoodRecipes.Domain.Primitives;

namespace FoodRecipes.Application.Abstractions.Data;

// Generic repository interface for managing aggregate roots
public interface IRepository<in T>
    where T : AggregateRoot
{
    // The 'in' keyword makes T contravariant. 
    // This means we can use a base class or interface of T.
}
