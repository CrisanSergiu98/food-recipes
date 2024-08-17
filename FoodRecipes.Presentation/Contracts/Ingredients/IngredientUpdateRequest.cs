namespace FoodRecipes.Presentation.Contracts.Ingredients;

public record IngredientUpdateRequest(
    Guid Id,
    string Name,
    string Description);