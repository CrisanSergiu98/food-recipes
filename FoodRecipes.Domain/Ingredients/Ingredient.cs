using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients;

// Domain model for an Ingredient
public class Ingredient : AggregateRoot
{
    protected Ingredient() : base(Guid.Empty)
    {
        // Required by EF Core
    }

    // Private constructor to initialize a new ingredient
    private Ingredient(
        Guid id,
        IngredientName ingredientName,
        IngredientDescription ingredientDescription
        ) : base(id)
    {
        Name = ingredientName;
        Description = ingredientDescription;
    }

    public IngredientName Name { get; set; }
    public IngredientDescription Description { get; set; }

    // Factory method to create a new ingredient
    public static Result<Ingredient> Create(
        Guid id,
        IngredientName ingredientName,
        IngredientDescription ingredientDescription)
    {
        var ingredient = new Ingredient(id, ingredientName, ingredientDescription);

        return Result.Success(ingredient);
    }

    // Method to update the ingredient with new values
    public Result UpdateIngredient(IngredientName updatedIngredientName, IngredientDescription updatedIngredientDescription)
    {
        Name = updatedIngredientName;
        Description = updatedIngredientDescription;

        return Result.Success();
    }
}
