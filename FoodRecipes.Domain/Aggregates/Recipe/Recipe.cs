using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe;

public sealed class Recipe : AggregateRoot
{
    private readonly HashSet<RecipeIngredient> _recipeIngredients = new();
    private readonly HashSet<RecipeStep> _steps = new();

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

    public Result<RecipeIngredient> AddIngredient(RecipeIngredient ingredient)
    {
        _recipeIngredients.Add(ingredient);

        return Result.Success(ingredient);
    }

    public Result<RecipeStep> AddStep(RecipeStep step) 
    {
        _steps.Add(step);

        return Result.Success(step);
    }
}
