using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects;

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
            return Result.Failure<IngredientDescription>(new Error(
                "Error.IngredientDescription.Empty",
                "The description is empty"));
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<IngredientDescription>(new Error(
                "Error.IngredientDescription.MaxLengthExceeded",
                $"The description has more than {MaxLength} characters"));
        }

        return new IngredientDescription(value);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
