using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;

public class GetAllIngredientsQueryHandler : IQueryHandler<GetAllIngredientsQuery, Result<List<Ingredient>>>
{
    private readonly IIngredientRepository _ingredientRepository;

    public GetAllIngredientsQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result<List<Ingredient>>> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = await _ingredientRepository.GetAll(cancellationToken);

        if(ingredients.Count == 0)
            return Result.Failure<List<Ingredient>>(IngredientErrors.NoIngredientFound);

        return Result.Success<List<Ingredient>>(ingredients);
    }
}

