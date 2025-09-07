using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

// Command handler for creating a new recipe
internal sealed class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand, Result<Guid>>
{
    private readonly IIngredientRepository _ingredients;
    private readonly IRecipeRepository _recipes;

    // Constructor to initialize repositories
    public CreateRecipeCommandHandler(
        IIngredientRepository ingredients,
        IRecipeRepository recipes)
    {
        _ingredients = ingredients;
        _recipes = recipes;
    }

    // Handles the create recipe command
    public async Task<Result<Guid>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        // Check if the recipe title already exists
        if (_recipes.TitleExists(request.Title, cancellationToken).Result)
            return Result.Failure<Guid>(RecipeErrors.TitleAlreadyExists);

        // Create value object for recipe title
        var recipeTitle = RecipeTitle.Create(request.Title);

        if (recipeTitle.IsFailure)
            return Result.Failure<Guid>(recipeTitle.Error);

        // Create value object for recipe description
        var recipeDescription = RecipeDescription.Create(request.Description);

        if (recipeDescription.IsFailure)
            return Result.Failure<Guid>(recipeDescription.Error);

        // Initialize collections for ingredients and steps
        HashSet<RecipeIngredient> ingredients = new HashSet<RecipeIngredient>();
        HashSet<RecipeStep> steps = new HashSet<RecipeStep>();

        // Process each ingredient in the request
        foreach (var ingredient in request.Ingredients)
        {
            // Retrieve the ingredient by ID
            var ingredientIdResult = await _ingredients.GetById(ingredient.IngredientId, cancellationToken);

            // Check if the ingredient exists
            if ((object)ingredientIdResult == null)
                return Result.Failure<Guid>(IngredientErrors.NotFound);

            // Create a value object for the ingredient
            var ingredientResult = RecipeIngredient.Create(ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);

            if (ingredientResult.IsFailure)
                return Result.Failure<Guid>(ingredientResult.Error);

            ingredients.Add(ingredientResult.Value);
        }

        // Process each step in the request
        foreach (var step in request.Steps)
        {
            // Create a value object for the step
            var stepResult = RecipeStep.Create(step);

            if (stepResult.IsFailure)
                return Result.Failure<Guid>(stepResult.Error);

            steps.Add(stepResult.Value);
        }

        // Create the recipe with new values
        var recipe = Recipe.CreateRecipe(
            Guid.NewGuid(),
            recipeTitle.Value,
            recipeDescription.Value,
            ingredients,
            steps);

        if (recipe.IsFailure)
            return Result.Failure<Guid>(recipe.Error);

        // Save the new recipe
        _recipes.Insert(recipe.Value, cancellationToken);

        return Result.Success<Guid>(recipe.Value.Id);
    }
}
