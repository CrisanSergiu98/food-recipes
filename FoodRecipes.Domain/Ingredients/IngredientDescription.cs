using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients;

public sealed class IngredientDescription : ValueObject
{
    private const int MaxLength = 200;

    private IngredientDescription(string value)
    {
        Value = value;
    }

    public string Value { get; private set; }

    public static Result<IngredientDescription> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<IngredientDescription>(IngredientErrors.DescriptionIsEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<IngredientDescription>(IngredientErrors.DescriptionMaxLengthExceeded);
        }

        return new IngredientDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static int GetMaxLength() => MaxLength;
}
