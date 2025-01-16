using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Recipes;

namespace FoodRecipes.Application.Dto;

// Static class for converting domain models to DTOs
public static class DtoConverter
{
    // Converts an Ingredient domain model to an IngredientDto
    public static IngredientDto IngredientDtoConvert(Ingredient ingredient)
    {
        return new IngredientDto(
            ingredient.Id,
            ingredient.Name.Value,
            ingredient.Description.Value
        );
    }

    // Converts a collection of Ingredient domain models to a collection of IngredientDtos
    public static IEnumerable<IngredientDto> IngredientDtoConvert(IEnumerable<Ingredient> ingredients)
    {
        var result = new List<IngredientDto>();

        foreach (var i in ingredients)
        {
            result.Add(IngredientDtoConvert(i));
        }

        return result;
    }

    // Converts a Recipe domain model to a RecipeDto
    public static RecipeDto RecipeDtoConvert(Recipe recipe)
    {
        var recipeIngredients = new List<RecipeIngredientDto>();
        var recipeSteps = new List<string>();

        // Convert each RecipeIngredient to RecipeIngredientDto
        foreach (var i in recipe.Ingredients)
        {
            recipeIngredients.Add(new RecipeIngredientDto(
                i.IngredientId,
                i.Quantity.Value,
                i.Unit.ToString()));
        }

        // Convert each RecipeStep to a string
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

    // Converts a collection of Recipe domain models to a collection of RecipeDtos
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
