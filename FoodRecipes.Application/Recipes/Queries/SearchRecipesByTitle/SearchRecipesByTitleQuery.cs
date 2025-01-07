using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.SearchRecipesByTitle;

public record SearchRecipesByTitleQuery(string Title):IQuery<Result<IEnumerable<Recipe>>>;
