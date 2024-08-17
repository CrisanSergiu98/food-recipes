using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.CreateIngredient;

public record CreateIngredientCommand(
    string Name,
    string Description
    ):ICommand<Result>;
