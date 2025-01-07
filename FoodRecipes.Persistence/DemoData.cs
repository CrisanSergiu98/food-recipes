using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Recipes;
using System.Reflection.Metadata.Ecma335;

namespace FoodRecipes.Persistence;

internal static class DemoData
{   

    public static List<Ingredient> GetDemoIngredients()
    {
        string[] ingredientNames = { "Potato", "Bread", "Pasta", "Chicken" };

        var Ingredients = new List<Ingredient>();

        foreach (var i in ingredientNames)
        {
            var ingredient = Ingredient.Create(
                Guid.NewGuid(),
                IngredientName.Create(i).Value,
                IngredientDescription.Create("Ingredient Description").Value
                );

            Ingredients.Add(ingredient.Value);
        }

        return Ingredients;
    }
}
