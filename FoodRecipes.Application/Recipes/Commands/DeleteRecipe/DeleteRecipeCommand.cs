using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.DeleteRecipe;

public record DeleteRecipeCommand(Guid Id):ICommand<Result>;