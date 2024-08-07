using FoodRecipes.Domain.Primitives;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.ValueObjects;

namespace FoodRecipes.Domain.Aggregates.Ingredient;

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
        return new Ingredient(id, ingredientName, ingredientDescription);
    }
}
