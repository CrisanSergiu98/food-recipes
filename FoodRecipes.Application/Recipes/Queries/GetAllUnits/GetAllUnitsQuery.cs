using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllUnits;

public record GetAllUnitsQuery() : IQuery<Result<string[]>>;
