using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetIngredient;

public record GetIngredientQuery(Guid IngredientId) : IQuery<Result<Ingredient>>;