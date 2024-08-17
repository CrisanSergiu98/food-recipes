namespace FoodRecipes.Presentation.Contracts;

public record IngredientUpdateRequest(
    Guid Id, 
    string Name, 
    string Description);