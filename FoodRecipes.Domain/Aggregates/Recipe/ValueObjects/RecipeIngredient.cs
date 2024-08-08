using FoodRecipes.Domain.Aggregates.Recipe.Enums;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Recipe.ValueObjects
{
    internal sealed class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(
            Guid ingredientId,
            IngredientQuantity quantity,
            Measurement measurement)
        {
            IngredientId = ingredientId;
            Quantity = quantity;
            Measurement = measurement;
        }

        public Guid IngredientId { get; private set; }
        public IngredientQuantity Quantity { get; private set; }
        public Measurement Measurement { get; private set; }

        public static Result<RecipeIngredient> Create(
            Guid ingredientId,
            IngredientQuantity quantity,
            Measurement measurement)
        {
            //Add Validation

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
