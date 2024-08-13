using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using System.Reflection.Metadata.Ecma335;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

public sealed class IngredientQuantity : ValueObject
{
    private const float MinValue = 1;
    private const float MaxValue = 9999;
    public float Value { get; private set; }
    private IngredientQuantity(float value)
    {
        Value = value;
    }
    public static Result<IngredientQuantity> Craete(float value)
    {
        if (value < MinValue)
            return Result.Failure<IngredientQuantity>(RecipeErrors.RecipeIngredientQuanityLessThanMinValue);

        if (value > MaxValue)
            return Result.Failure<IngredientQuantity>(RecipeErrors.RecipeIngredientQuanityHigherThanMaxValue);

        return Result.Success(new IngredientQuantity(value));
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static float GetMinValue() => MinValue;

    public static float GetMaxValue() => MaxValue;

}