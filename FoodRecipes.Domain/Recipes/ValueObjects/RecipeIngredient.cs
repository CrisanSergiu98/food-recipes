using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Recipes.ValueObjects
{
    // Value object for a recipe ingredient
    public sealed class RecipeIngredient : ValueObject
    {
        // Private constructor to initialize the recipe ingredient
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

        // Factory method to create a new recipe ingredient
        public static Result<RecipeIngredient> Create(
            Guid ingredientId,
            float quantity,
            string unit)
        {
            // Create value object for ingredient quantity
            var quantityResult = IngredientQuantity.Craete(quantity);

            if (quantityResult.IsFailure)
                return Result.Failure<RecipeIngredient>(quantityResult.Error);

            // Parse the unit string to the Unit enum
            if (!Enum.TryParse<Unit>(unit, true, out var parsedUnit))
                return Result.Failure<RecipeIngredient>(RecipeErrors.UnitIsNotValid);

            return new RecipeIngredient(
            ingredientId,
            quantityResult.Value,
            parsedUnit);
        }

        // Get the atomic values of the recipe ingredient
        public override IEnumerable<object> GetAtomicValues()
        {
            yield return IngredientId;
            yield return Quantity;
            yield return Unit;
        }
    }
}
