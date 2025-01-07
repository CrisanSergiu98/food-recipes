using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.SearchIngredientByName;

public record SearchIngredientsByNameQuery(
    string Name
    ):IQuery<Result<IEnumerable<Ingredient>>>;
