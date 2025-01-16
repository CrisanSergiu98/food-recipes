using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Recipes.ValueObjects;

namespace FoodRecipes.Domain.Recipes;

// Domain model for a Recipe
public class Recipe : AggregateRoot
{
    private readonly HashSet<RecipeIngredient> _recipeIngredients = new();
    private readonly HashSet<RecipeStep> _recipeSteps = new();

    // Private constructor to initialize a new recipe
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
    public List<RecipeIngredient> Ingredients => _recipeIngredients.ToList();
    public List<RecipeStep> Steps => _recipeSteps.ToList();

    // Factory method to create a new recipe
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

        // Add ingredients to the recipe
        foreach (var ingredient in ingredients)
        {
            var ingredientResult = recipe.CreateRecipeIngredient(ingredient);

            if (ingredientResult.IsFailure)
                return Result.Failure<Recipe>(ingredientResult.Error);
        }

        // Add steps to the recipe
        foreach (var step in steps)
        {
            var stepResult = recipe.CreateRecipeStep(step);

            if (stepResult.IsFailure)
                return Result.Failure<Recipe>(stepResult.Error);
        }

        return Result.Success(recipe);
    }

    // Method to add an ingredient to the recipe
    public Result CreateRecipeIngredient(RecipeIngredient ingredientToAdd)
    {
        if (_recipeIngredients.Any(ingredient => ingredient.IngredientId == ingredientToAdd.IngredientId))
            return Result.Failure(RecipeErrors.IngredientAlreadyExists);

        _recipeIngredients.Add(ingredientToAdd);

        return Result.Success();
    }

    // Method to update the recipe with new values
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

        // Add new ingredients to the recipe
        foreach (var ingredient in ingredients)
        {
            var ingredientResult = CreateRecipeIngredient(ingredient);

            if (ingredientResult.IsFailure)
                return Result.Failure(ingredientResult.Error);
        }

        // Add new steps to the recipe
        foreach (var step in steps)
        {
            var stepResult = CreateRecipeStep(step);

            if (stepResult.IsFailure)
                return Result.Failure(stepResult.Error);
        }

        return Result.Success();
    }

    // Method to add a step to the recipe
    public Result CreateRecipeStep(RecipeStep stepToAdd)
    {
        if (_recipeSteps.Any(step => step.Value == stepToAdd.Value))
            return Result.Failure(RecipeErrors.StepAlreadyExists);

        _recipeSteps.Add(stepToAdd);

        return Result.Success();
    }
}
