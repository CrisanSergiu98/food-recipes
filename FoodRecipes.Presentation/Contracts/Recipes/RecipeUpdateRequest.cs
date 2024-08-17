namespace FoodRecipes.Presentation.Contracts.Recipes;

public record RecipeUpdateRequest(
    Guid Id,
    string Title,
    string Description,
    HashSet<(Guid, float, string)> Ingredients,
    HashSet<(int, string)> Steps
    );