using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;

public record GetAllIngredientsQuery() : IQuery<Result<List<Ingredient>>>;