using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.UpdateRecipe;

internal sealed class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientRepository _ingredientRepository;

    public UpdateRecipeCommandHandler(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }
    public async Task<Result> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        var recipeResult = _recipeRepository.GetById(request.Id);

        if (recipeResult.Result is null)
            return Result.Failure(RecipeErrors.RecipeNotFound);
        

        var recipeTitle = RecipeTitle.Create(request.Title);
        var recipeDescription = RecipeDescription.Create(request.Description);

        var result = Result.FirstFailureOrSuccess(recipeTitle, recipeDescription);

        if(result.IsFailure) 
            return Result.Failure(result.Error);

        HashSet<RecipeIngredient> ingredients = new HashSet<RecipeIngredient>();
        HashSet<RecipeStep> steps = new HashSet<RecipeStep>();

        foreach (var ingredient in request.Ingredients)
        {
            var ingredientIdResult = await _ingredientRepository.GetById(ingredient.IngredientId, cancellationToken);

            if ((object)ingredientIdResult == null)
                return Result.Failure(IngredientErrors.NotFound);

            //Create the RecipeIngredient ValueObject
            var ingredientResult = RecipeIngredient.Create(ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);

            if (ingredientResult.IsFailure)
                return Result.Failure(ingredientResult.Error);

            //Add the RecipeIngredient to the hashset
            ingredients.Add(ingredientResult.Value);
        }

        foreach (var step in request.Steps)
        {
            var stepResult = RecipeStep.Create(step);

            if (stepResult.IsFailure)
                return Result.Failure(stepResult.Error);

            steps.Add(stepResult.Value);
        }

        var updateResult = recipeResult.Result.UpdateRecipe(
            recipeTitle.Value,
            recipeDescription.Value,
            ingredients,
            steps);

        _recipeRepository.Update(recipeResult.Result);

        return Result.Success(updateResult);
    }
}
