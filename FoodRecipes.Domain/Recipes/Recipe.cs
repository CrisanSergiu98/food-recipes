using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Aggregates.Recipes.Enums;
using FoodRecipes.Domain.Common.ValueObjects;
using FoodRecipes.Domain.Recipes.DTOs;
using FoodRecipes.Domain.Recipes.ValueObjects;

namespace FoodRecipes.Domain.Recipes;

public class Recipe : AggregateRoot
{
    private readonly HashSet<RecipeIngredient> _recipeIngredients = new();
    private readonly HashSet<RecipeStep> _recipeSteps = new();

    private Recipe(
        Guid id,
        RecipeTitle title,
        RecipeDescription description,
        HashSet<RecipeIngredientDto> ingredients,
        HashSet<RecipeStepDto> steps
        ) : base(id)
    {
        Title = title;
        Description = description;

        foreach (var ingredient in ingredients)
        {
            CreateRecipeIngredient(ingredient.IngredientId, ingredient.Quantity, ingredient.Measurement);
        }

        foreach (var step in steps)
        {
            CreateRecipeStep(step.StepNumber, step.Description);
        }
    }

    public RecipeTitle Title { get; private set; }
    public RecipeDescription Description { get; private set; }

    public static Result<Recipe> CreateRecipe(
        Guid id,
        RecipeTitle title,
        RecipeDescription description,
        HashSet<RecipeIngredientDto> ingredients,
        HashSet<RecipeStepDto> steps)
    {
        var recipe = new Recipe(
            id,
            title,
            description,
            ingredients,
            steps);

        return Result.Success(recipe);
    }

    public Result CreateRecipeIngredient(Guid ingredientId, float quanity, Unit measurement)
    {
        var ingredientResponse = RecipeIngredient.Create(
            ingredientId,
            quanity,
            measurement);

        if (ingredientResponse.IsFailure)
        {
            return Result.Failure(ingredientResponse.Error);
        }

        _recipeIngredients.Add(ingredientResponse.Value);

        return Result.Success();
    }

    public Result RemoveIngredient(Guid ingredientId)
    {
        var ingredient = _recipeIngredients.FirstOrDefault(i => i.IngredientId == ingredientId);

        if (ingredient == null)
        {
            return Result.Failure(RecipeErrors.IngredientNotFound);
        }

        _recipeIngredients.Remove(ingredient);

        return Result.Success();
    }

    public Result CreateRecipeStep(StepNumber number, StepDescription description)
    {
        var stepResponse = RecipeStep.Create(number, description);

        if (stepResponse.IsFailure)
        {
            return Result.Failure(stepResponse.Error);
        }

        _recipeSteps.Add(stepResponse.Value);

        return Result.Success();
    }

    public Result RemoveStep(StepNumber number)
    {
        var step = _recipeSteps.FirstOrDefault(i => i.Number == number);

        if (step == null)
        {
            return Result.Failure(RecipeErrors.StepNotFound);
        }

        _recipeSteps.Remove(step);

        return Result.Success();
    }
}