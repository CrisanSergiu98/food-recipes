

using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.DeleteIngredient;

public record DeleteIngredientCommand(Guid Id):ICommand<Result>;

