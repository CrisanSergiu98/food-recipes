using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;

public record UpdateIngredientCommand(
    Guid Id,
    string Name,
    string Description
    ) : ICommand<Result>;
