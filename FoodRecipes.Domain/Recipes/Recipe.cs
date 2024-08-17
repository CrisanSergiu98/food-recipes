using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
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
        HashSet<RecipeIngredient> ingredients,
        HashSet<RecipeStep> steps
        ) : base(id)
    {
        Title = title;
        Description = description;

        foreach (var ingredient in ingredients)
        {
            CreateRecipeIngredient(ingredient);
        }

        foreach (var step in steps)
        {
            CreateRecipeStep(step);
        }
    }

    public RecipeTitle Title { get; private set; }
    public RecipeDescription Description { get; private set; }

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
            description,
            ingredients,
            steps);

        return Result.Success(recipe);
    }

    public Result CreateRecipeIngredient(RecipeIngredient ingredientToAdd)
    {
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
            CreateRecipeIngredient(ingredient);
        }

        foreach (var step in steps)
        {
            CreateRecipeStep(step);
        }

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

    public Result CreateRecipeStep(RecipeStep stepToAdd)
    {       
        _recipeSteps.Add(stepToAdd);

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