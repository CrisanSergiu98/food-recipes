namespace FoodRecipes.Presentation.Contracts.Recipes;

public record RecipeCreateRequest(
    string Title,
    string Description,
    HashSet<(Guid, float, string)> Ingredients,
    HashSet<(int, string)> Steps);