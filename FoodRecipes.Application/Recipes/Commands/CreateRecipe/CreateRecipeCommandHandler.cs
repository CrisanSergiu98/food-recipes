using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Recipes;
using FoodRecipes.Domain.Recipes.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Commands.CreateRecipe;

internal sealed class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand, Result<Guid>>
{
    private readonly IIngredientRepository _ingredients;
    private readonly IRecipeRepository _recipes;

    public CreateRecipeCommandHandler(
        IIngredientRepository ingredients, 
        IRecipeRepository recipes)
    {
        _ingredients = ingredients;
        _recipes = recipes;
    }

    public async Task<Result<Guid>> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
    {
        if(_recipes.TitleExists(request.Title, cancellationToken).Result)
            return Result.Failure<Guid>(RecipeErrors.TitleAlreadyExists);

        var recipeTitle = RecipeTitle.Create(request.Title);

        if (recipeTitle.IsFailure)
            return Result.Failure<Guid>(recipeTitle.Error);
        
        var recipeDescription = RecipeDescription.Create(request.Description);

        if (recipeDescription.IsFailure)
            return Result.Failure<Guid>(recipeDescription.Error);

        HashSet<RecipeIngredient> ingredients = new HashSet<RecipeIngredient>();
        HashSet<RecipeStep> steps = new HashSet<RecipeStep>();

        foreach (var ingredient in request.Ingredients)
        {

            var ingredientIdResult = await _ingredients.GetById(ingredient.IngredientId, cancellationToken);

            if((object)ingredientIdResult == null)
                return Result.Failure<Guid>(IngredientErrors.NotFound);

            var ingredientResult = RecipeIngredient.Create(ingredient.IngredientId, ingredient.Quantity, ingredient.Unit);

            if (ingredientResult.IsFailure)
                return Result.Failure<Guid>(ingredientResult.Error);

            ingredients.Add(ingredientResult.Value);
        }

        foreach(var step in request.Steps)
        {
            var stepResult = RecipeStep.Create(step);

            if (stepResult.IsFailure)
                return Result.Failure<Guid>(stepResult.Error);

            steps.Add(stepResult.Value);
        }

        var recipe = Recipe.CreateRecipe(
            Guid.NewGuid(),
            recipeTitle.Value, 
            recipeDescription.Value, 
            ingredients,
            steps);

        if(recipe.IsFailure)
            return Result.Failure<Guid>(recipe.Error);

        _recipes.Insert(recipe.Value);

        return Result.Success<Guid>(recipe.Value.Id);
    }    
}
