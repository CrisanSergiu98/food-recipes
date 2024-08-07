using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe.ValueObjects
{
    internal sealed class RecipeStep : ValueObject
    {
        private RecipeStep(
            int number,
            RecipeStepDescription description)
        {
            Number = number;
            Description = description;
        }

        public int Number { get; private set; }
        public RecipeStepDescription Description { get; private set; }

        public static Result<RecipeStep> Create(
            int number,
            RecipeStepDescription description)
        {
            //+++ Validate number and descriprion
            return new RecipeStep(number, description);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Number;
            yield return Description;
        }

        public void Reindex(int index)
        {
            Number = index;
        }
    }
}
