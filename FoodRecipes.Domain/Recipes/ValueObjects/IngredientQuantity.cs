using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

// Value object for ingredient quantity
public sealed class IngredientQuantity : ValueObject
{
    private const float MinValue = 1;
    private const float MaxValue = 9999;

    public float Value { get; private set; }

    // Private constructor to initialize the ingredient quantity
    public IngredientQuantity(float value)
    {
        Value = value;
    }

    // Factory method to create a new ingredient quantity
    public static Result<IngredientQuantity> Craete(float value)
    {
        // Check if the quantity is less than the minimum value
        if (value < MinValue)
            return Result.Failure<IngredientQuantity>(RecipeErrors.RecipeIngredientQuanityLessThanMinValue);

        // Check if the quantity exceeds the maximum value
        if (value > MaxValue)
            return Result.Failure<IngredientQuantity>(RecipeErrors.RecipeIngredientQuanityHigherThanMaxValue);

        return Result.Success(new IngredientQuantity(value));
    }

    // Get the atomic values of the ingredient quantity
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    // Get the minimum value of the ingredient quantity
    public static float GetMinValue() => MinValue;

    // Get the maximum value of the ingredient quantity
    public static float GetMaxValue() => MaxValue;
}
