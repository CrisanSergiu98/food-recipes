using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Domain.Ingredients;

public class Ingredient : AggregateRoot
{
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
    public static Result<Ingredient> Create(
        Guid id,
        IngredientName ingredientName,
        IngredientDescription ingredientDescription)
    {
        var ingredient = new Ingredient(id, ingredientName, ingredientDescription);

        return Result.Success(ingredient);
    }

    public Result UpdateIngredient(IngredientName updatedIngredientName, IngredientDescription updatedIngredientDescription)
    {
        Name = updatedIngredientName;
        Description = updatedIngredientDescription;

        return Result.Success();
    }
}
