using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllRecipes;

public record GetAllRecipesQuery():IQuery<Result<List<Recipe>>>;
