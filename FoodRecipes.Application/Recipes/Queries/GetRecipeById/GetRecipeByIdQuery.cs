using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetRecipeById;

public record GetRecipeByIdQuery(Guid Id) : IQuery<Result<Recipe>>;

