using FoodRecipes.Domain.Aggregates.Recipes.Enums;
using FoodRecipes.Domain.Common.ValueObjects;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects
{
    internal sealed class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(
            Guid ingredientId,
            IngredientQuantity quantity,
            Unit measurement)
        {
            IngredientId = ingredientId;
            Quantity = quantity;
            Measurement = measurement;
        }

        public Guid IngredientId { get; private set; }
        public IngredientQuantity Quantity { get; private set; }
        public Unit Measurement { get; private set; }

        public static Result<RecipeIngredient> Create(
            Guid ingredientId,
            float quantity,
            Unit measurement)
        {
            var quantityResult = IngredientQuantity.Craete(quantity);

            if (quantityResult.IsFailure)
            {
                return Result.Failure<RecipeIngredient>(quantityResult.Error);
            }

            return new RecipeIngredient(
                ingredientId,
                quantityResult.Value,
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
