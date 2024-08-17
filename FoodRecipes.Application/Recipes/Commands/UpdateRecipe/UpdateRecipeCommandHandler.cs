using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Common.ValueObjects;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.UpdateRecipe;

internal class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;
    public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeResult = _recipeRepository.GetById(request.Id);

        if (recipeResult.Value == null)
            return Result.Failure(new Error("", ""));
        

        var recipeTitle = RecipeTitle.Create(request.Title);
        var recipeDescription = RecipeDescription.Create(request.Description);

        var result = Result.FirstFailureOrSuccess(recipeTitle, recipeDescription, recipeResult);

        if(result.IsFailure) 
            return Result.Failure(result.Error);

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
                return Result.Failure(ingredientResult.Error);
            
            ingredients.Add(ingredientResult.Value);
        }

        foreach (var step in steps)
        {
            var stepResult = RecipeStep.Create(step.Number, step.Description);

            if (stepResult.IsFailure)
                return Result.Failure(stepResult.Error);
            
            steps.Add(stepResult.Value);
        }

        var updateResult = recipeResult.Value.UpdateRecipe(
            recipeTitle.Value,
            recipeDescription.Value,
            ingredients,
            steps);

        _recipeRepository.Update(recipeResult.Value);

        return Result.Success(updateResult);
    }
    private static T ParseEnum<T>(string value)
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }
}
