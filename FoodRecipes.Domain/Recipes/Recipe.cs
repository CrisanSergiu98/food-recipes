using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Recipes.ValueObjects;

namespace FoodRecipes.Domain.Recipes;

public class Recipe : AggregateRoot
{
    private readonly HashSet<RecipeIngredient> _recipeIngredients = [];
    private readonly HashSet<RecipeStep> _recipeSteps = [];

    protected Recipe() : base(Guid.Empty)
    {
        // Required by EF Core
    }

    private Recipe(
        Guid id,
        RecipeTitle title,
        RecipeDescription description
        ) : base(id)
    {
        Title = title;
        Description = description;
    }

    public RecipeTitle Title { get; private set; }
    public RecipeDescription Description { get; private set; }
    public List<RecipeIngredient> Ingredients => [.. _recipeIngredients];
    public List<RecipeStep> Steps => [.. _recipeSteps];

    public static Result<Recipe> CreateRecipe(
        Guid id,
        RecipeTitle title,
        RecipeDescription description,
        HashSet<RecipeIngredient> ingredients,
        HashSet<RecipeStep> steps)
    {
        var recipe = new Recipe(
            id,
            title,
            description);

        foreach (var ingredient in ingredients)
        {
            var ingredientResult = recipe.CreateRecipeIngredient(ingredient);

            if (ingredientResult.IsFailure)
                return Result.Failure<Recipe>(ingredientResult.Error);
        }

        foreach (var step in steps)
        {
            var stepResult = recipe.CreateRecipeStep(step);

            if (stepResult.IsFailure)
                return Result.Failure<Recipe>(stepResult.Error);
        }

        return Result.Success(recipe);
    }

    public Result CreateRecipeIngredient(RecipeIngredient ingredientToAdd)
    {
        if (_recipeIngredients.Any(ingredient => ingredient.IngredientId == ingredientToAdd.IngredientId))
            return Result.Failure(RecipeErrors.IngredientAlreadyExists);

        _recipeIngredients.Add(ingredientToAdd);

        return Result.Success();
    }

    public Result UpdateRecipe(
        RecipeTitle title,
        RecipeDescription description,
        HashSet<RecipeIngredient> ingredients,
        HashSet<RecipeStep> steps)
    {
        Title = title;
        Description = description;

        _recipeIngredients.Clear();
        _recipeSteps.Clear();

        foreach (var ingredient in ingredients)
        {
            var ingredientResult = CreateRecipeIngredient(ingredient);

            if (ingredientResult.IsFailure)
                return Result.Failure(ingredientResult.Error);
        }

        foreach (var step in steps)
        {
            var stepResult = CreateRecipeStep(step);

            if (stepResult.IsFailure)
                return Result.Failure(stepResult.Error);
        }

        return Result.Success();
    }

    public Result CreateRecipeStep(RecipeStep stepToAdd)
    {
        if (_recipeSteps.Any(step => step.Value == stepToAdd.Value))
            return Result.Failure(RecipeErrors.StepAlreadyExists);

        _recipeSteps.Add(stepToAdd);

        return Result.Success();
    }
}
