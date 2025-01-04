using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Application.Ingredients.Queries.GetIngredient;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Queries.GetIngredient
{
    internal class GetIngredientQueryHandler : IQueryHandler<GetIngredientQuery, Result<Ingredient>>
    {
        private readonly IIngredientRepository _ingredientRepository;

        public GetIngredientQueryHandler(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public async Task<Result<Ingredient>> Handle(GetIngredientQuery request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetById(request.IngredientId, cancellationToken);

            if (ingredient == null)
                return Result.Failure<Ingredient>(IngredientErrors.NotFound);

            return ingredient;
        }
    }
}
