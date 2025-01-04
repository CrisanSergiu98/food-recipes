using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetAllIngredients;

public class GetAllIngredientsQueryHandler : IQueryHandler<GetAllIngredientsQuery, Result>
{
    private readonly IIngredientRepository _ingredientRepository;

    public GetAllIngredientsQueryHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result> Handle(GetAllIngredientsQuery request, CancellationToken cancellationToken)
    {
        var ingredients = _ingredientRepository.GetAll(cancellationToken);

        if(ingredients == null)
            return Result.Failure(new Error("",""));

        return Result.Success(ingredients);
    }
}

