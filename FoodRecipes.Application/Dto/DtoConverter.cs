using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Dto;

public static class DtoConverter
{
    public static IngredientDto IngredientDtoConvert(Ingredient ingredient)
    {
        return new IngredientDto(
            ingredient.Id,
            ingredient.Name.Value,
            ingredient.Description.Value
        );
    }
    public static IEnumerable<IngredientDto> IngredientDtoConvert(IEnumerable<Ingredient> ingredients)
    {
        var result = new List<IngredientDto>();

        foreach (var i in ingredients)
        {
            result.Add(IngredientDtoConvert(i));
        }

        return result;
    }
    public static RecipeDto RecipeDtoConvert(Recipe recipe)
    {
        var recipeIngredients = new List<RecipeIngredientDto>();
        var recipeSteps = new List<string>();

        foreach (var i in recipe.Ingredients)
        {
            recipeIngredients.Add(new RecipeIngredientDto(
                i.IngredientId,
                i.Quantity.Value,
                i.Unit.ToString()));
        }

        foreach (var s in recipe.Steps)
        {
            recipeSteps.Add(s.Value);
        }

        return new RecipeDto(
            recipe.Id,
            recipe.Title.Value,
            recipe.Description.Value,
            recipeIngredients,
            recipeSteps);
    }

    public static List<RecipeDto> RecipesDtoConvert(IEnumerable<Recipe> recipes)
    {
        var result = new List<RecipeDto>();

        foreach (var recipe in recipes)
        {
            result.Add(RecipeDtoConvert(recipe));
        }

        return result;
    }
}
