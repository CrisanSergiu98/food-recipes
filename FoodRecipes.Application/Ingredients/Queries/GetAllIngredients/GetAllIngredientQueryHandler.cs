using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
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
        var ingredients = _ingredientRepository.GetAll(cancellationToken);

        if((object)ingredients == null)
            return Result.Failure<List<Ingredient>>(new Error("",""));

        return Result.Success<List<Ingredient>>(ingredients.Result);
    }
}

