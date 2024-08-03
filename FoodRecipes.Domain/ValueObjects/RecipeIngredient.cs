using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Aggregates.Recipe
{
    public sealed class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(
            Guid ingredientId,
            float quantity,
            Measurement measurement)
        {
            IngredientId = ingredientId;
            Quantity = quantity;
            Measurement = measurement;
        }

        public Guid IngredientId { get; private set; }
        public float Quantity { get; private set; }
        public Measurement Measurement { get; private set; }

        public static Result<RecipeIngredient> Create(
            Guid ingredientId,
            float quantity,
            Measurement measurement)
        {
            //+++ Validate number and descriprion
            return new RecipeIngredient(
                ingredientId,
                quantity,
                measurement);             
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return IngredientId;
            yield return Quantity;
            yield return Measurement;
        }
    }
}
