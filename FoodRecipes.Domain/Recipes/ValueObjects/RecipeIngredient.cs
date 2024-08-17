using FoodRecipes.Domain.Common.ValueObjects;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects
{
    public sealed class RecipeIngredient : ValueObject
    {
        private RecipeIngredient(
            Guid ingredientId,
            IngredientQuantity quantity,
            Unit unit)
        {
            IngredientId = ingredientId;
            Quantity = quantity;
            Unit = unit;
        }

        public Guid IngredientId { get; private set; }
        public IngredientQuantity Quantity { get; private set; }
        public Unit Unit { get; private set; }

        public static Result<RecipeIngredient> Create(
            Guid ingredientId,
            float quantity,
            Unit unit)
        {
            var quantityResult = IngredientQuantity.Craete(quantity);

            if (quantityResult.IsFailure)
            {
                return Result.Failure<RecipeIngredient>(quantityResult.Error);
            }

            return new RecipeIngredient(
                ingredientId,
                quantityResult.Value,
                unit);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return IngredientId;
            yield return Quantity;
            yield return Unit;
        }
    }
}
