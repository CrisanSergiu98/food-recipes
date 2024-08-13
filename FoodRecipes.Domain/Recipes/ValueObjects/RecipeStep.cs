using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects
{
    internal sealed class RecipeStep : ValueObject
    {
        private RecipeStep(
            StepNumber number,
            StepDescription description)
        {
            Number = number;
            Description = description;
        }

        public StepNumber Number { get; private set; }
        public StepDescription Description { get; private set; }

        public static Result<RecipeStep> Create(
            StepNumber number,
            StepDescription description)
        {
            return new RecipeStep(number, description);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
            yield return Description;
        }
    }
}
