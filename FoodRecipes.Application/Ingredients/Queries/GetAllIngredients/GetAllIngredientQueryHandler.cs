using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;

// Query handler for getting all ingredients
public class GetAllIngredientsQueryHandler : IQueryHandler<GetAllIngredientsQuery, Result<List<Ingredient>>>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public GetAllIngredientsQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the get all ingredients query
    public async Task<Result<List<Ingredient>>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all ingredients
        var ingredients = await _ingredientRepository.GetAll(cancellationToken);

        // Check if any ingredients were found
        if (ingredients.Count == 0)
            return Result.Failure<List<Ingredient>>(IngredientErrors.NoIngredientFound);

        return Result.Success<List<Ingredient>>(ingredients);
    }
}
