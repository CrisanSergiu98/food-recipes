using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Common.ValueObjects;
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

        HashSet<RecipeIngredient> ingredients = new HashSet<RecipeIngredient>();
        HashSet<RecipeStep> steps = new HashSet<RecipeStep>();

        foreach (var ingredient in request.Ingredients)
        {
            Unit unit;

            try
            {
                unit = ParseEnum<Unit>(ingredient.Item3);
            }
            catch (ArgumentException)
            {
                return Result.Failure(new Error("", "The Unit is incorrect."));
            }

            var ingredientResult = RecipeIngredient.Create(ingredient.Item1, ingredient.Item2, unit);

            if (ingredientResult.IsFailure)
            {
                return Result.Failure(ingredientResult.Error);
            }

            ingredients.Add(ingredientResult.Value);
        }

        foreach(var step in steps)
        {
            var stepResult = RecipeStep.Create(step.Number, step.Description);

            if (stepResult.IsFailure)
            {
                return Result.Failure(stepResult.Error);
            }

            steps.Add(stepResult.Value);
        }

        var recipe = Recipe.CreateRecipe(
            Guid.NewGuid(),
            recipeTitle.Value, 
            recipeDescription.Value, 
            ingredients,
            steps);

        if(recipe.IsFailure)
            return Result.Failure(recipe.Error);

        return Result.Success(recipe);
    }

    private static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}
