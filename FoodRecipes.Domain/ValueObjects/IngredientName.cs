using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.ValueObjects
{
    public sealed class IngredientName : ValueObject
    {
        private const int MaxLength = 50;

        private IngredientName(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        public static Result<IngredientName> Create(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<IngredientName>(new Error(
                    "Error.IngredientName.Empty",
                    "The name is empty"));
            }

            if (value.Length > MaxLength)
            {
                return Result.Failure<IngredientName>(new Error(
                    "Error.IngredientName.MaxLengthExceeded",
                    $"The name has more than {MaxLength} characters"));
            }

            return new IngredientName(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
