using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects;

public sealed class RecipeTitle : ValueObject
{
    private static int MaxLength = 100;

    private RecipeTitle(string value)
    {
        Value = value;
    }

    public string Value { get; set; }

    public static Result<RecipeTitle> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return Result.Failure<RecipeTitle>(RecipeErrors.RecipeTitleIsEmpty);
        }

        if (value.Length > MaxLength)
        {
            return Result.Failure<RecipeTitle>(RecipeErrors.RecipeTitleMaxLengthExceeded);
        }

        return new RecipeTitle(value);
    }

    public static int GetMaxLength() => MaxLength;

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
