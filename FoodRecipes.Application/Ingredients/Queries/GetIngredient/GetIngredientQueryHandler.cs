using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetIngredient;

// Query handler for getting an ingredient by ID
internal class GetIngredientQueryHandler : IQueryHandler<GetIngredientQuery, Result<Ingredient>>
{
    private readonly IIngredientRepository _ingredientRepository;

    // Constructor to initialize the ingredient repository
    public GetIngredientQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    // Handles the get ingredient by ID query
    public async Task<Result<Ingredient>> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
    {
        // Retrieve the ingredient by ID
        var ingredient = await _ingredientRepository.GetById(request.IngredientId, cancellationToken);

        // Check if the ingredient exists
        if (ingredient is null)
            return Result.Failure<Ingredient>(IngredientErrors.NotFound);

        return ingredient;
    }
}
