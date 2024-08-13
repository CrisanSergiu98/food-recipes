using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

internal class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand, Result>
{
    public async Task<Result> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeTitle = RecipeTitle.Create(request.Title);

        if (recipeTitle.IsFailure)
            return Result.Failure(recipeTitle.Error);

        var recipeDescription = RecipeDescription.Create(request.Description);

        if (recipeDescription.IsFailure)
            return Result.Failure(recipeDescription.Error);

        var recipe = Recipe.CreateRecipe(
            Guid.NewGuid(),
            recipeTitle.Value, 
            recipeDescription.Value, 
            request.Ingredients,
            request.Steps);

        if(recipe.IsFailure)
            return Result.Failure(recipe.Error);

        return Result.Success(recipe);
    }
}
