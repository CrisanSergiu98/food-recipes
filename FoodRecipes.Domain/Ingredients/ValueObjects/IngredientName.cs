using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients.ValueObjects
{
    // Value object for an ingredient name
    public sealed class IngredientName : ValueObject
    {
        private const int MaxLength = 50;

        // Private constructor to initialize the ingredient name
        private IngredientName(string value)
        {
            Value = value;
        }

        public string Value { get; set; }

        // Factory method to create a new ingredient name
        public static Result<IngredientName> Create(string value)
        {
            // Check if the name is empty
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<IngredientName>(IngredientErrors.NameIsEmpty);
            }

            // Check if the name exceeds the maximum length
            if (value.Length > MaxLength)
            {
                return Result.Failure<IngredientName>(IngredientErrors.NameMaxLengthExceeded);
            }

            return new IngredientName(value);
        }

        // Get the atomic values of the ingredient name
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        // Get the maximum length of the ingredient name
        public static int GetMaxLength() => MaxLength;
    }
}
