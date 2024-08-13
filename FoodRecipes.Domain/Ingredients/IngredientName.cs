using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients
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
                return Result.Failure<IngredientName>(IngredientErrors.NameIsEmpty);
            }

            if (value.Length > MaxLength)
            {
                return Result.Failure<IngredientName>(IngredientErrors.NameMaxLengthExceeded);
            }

            return new IngredientName(value);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        public static int GetMaxLength() => MaxLength;
    }
}
