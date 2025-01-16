using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects
{
    // Value object for a recipe step
    public sealed class RecipeStep : ValueObject
    {
        private const int MaxLength = 300;

        // Private constructor to initialize the recipe step
        private RecipeStep(string value)
        {
            Value = value;
        }

        public string Value { get; private set; }

        // Factory method to create a new recipe step
        public static Result<RecipeStep> Create(string value)
        {
            // Check if the step description is empty
            if (string.IsNullOrWhiteSpace(value))
            {
                return Result.Failure<RecipeStep>(RecipeErrors.StepDescriptionIsEmpty);
            }

            // Check if the step description exceeds the maximum length
            if (value.Length > MaxLength)
            {
                return Result.Failure<RecipeStep>(RecipeErrors.StepDescriptionMaxLengthExceeded);
            }

            return new RecipeStep(value);
        }

        // Get the atomic values of the recipe step
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        // Get the maximum length of the recipe step
        public static int GetMaxLength() => MaxLength;
    }
}
