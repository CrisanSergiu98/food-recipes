using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.UpdateRecipe;

// Command handler for updating a recipe
internal sealed class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand, Result>
{
    private readonly IRecipeRepository _recipeRepository;
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize repositories
    public UpdateRecipeCommandHandler(
        IRecipeRepository recipeRepository,
        IIngredientRepository ingredientRepository)
    {
        _recipeRepository = recipeRepository;
        _ingredientRepository = ingredientRepository;
    }

    // Handles the update recipe command
    public async Task<Result> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the recipe by ID
        var recipeResult = _recipeRepository.GetById(request.Id);

        // Check if the recipe exists
        if (recipeResult.Result is null)
            return Result.Failure(RecipeErrors.RecipeNotFound);

        // Create value objects for title and description
        var recipeTitle = RecipeTitle.Create(request.Title);
        var recipeDescription = RecipeDescription.Create(request.Description);

        // Check for any validation errors
        var result = Result.FirstFailureOrSuccess(recipeTitle, recipeDescription);

        if (result.IsFailure)
            return Result.Failure(result.Error);

        // Initialize collections for ingredients and steps
        HashSet<RecipeIngredient> ingredients = new HashSet<RecipeIngredient>();
        HashSet<RecipeStep> steps = new HashSet<RecipeStep>();

        // Process each ingredient in the request
        foreach (var ingredient in request.Ingredients)
        {
            // Retrieve the ingredient by ID
            var ingredientIdResult = await _ingredientRepository.GetById(ingredient.IngredientId, cancellationToken);

            // Check if the ingredient exists
            if ((object)ingredientIdResult == null)
                return Result.Failure(IngredientErrors.NotFound);

            // Create a value object for the ingredient
            var ingredientResult = RecipeIngredient.Create(ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);

            if (ingredientResult.IsFailure)
                return Result.Failure(ingredientResult.Error);

            ingredients.Add(ingredientResult.Value);
        }

        // Process each step in the request
        foreach (var step in request.Steps)
        {
            // Create a value object for the step
            var stepResult = RecipeStep.Create(step);

            if (stepResult.IsFailure)
                return Result.Failure(stepResult.Error);

            steps.Add(stepResult.Value);
        }

        // Update the recipe with new values
        var updateResult = recipeResult.Result.UpdateRecipe(
            recipeTitle.Value,
            recipeDescription.Value,
            ingredients,
            steps);

        if (updateResult.IsFailure)
            return Result.Failure(updateResult.Error);

        // Save the updated recipe
        _recipeRepository.Update(recipeResult.Result);

        return Result.Success();
    }
}
