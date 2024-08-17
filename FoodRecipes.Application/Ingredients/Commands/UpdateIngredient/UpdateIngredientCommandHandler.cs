using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.UpdateIngredient;

internal class UpdateIngredientCommandHandler : ICommandHandler<UpdateIngredientCommand, Result>
{
    private readonly IIngredientRepository _ingredientRepository;
    public UpdateIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
    {
        Ingredient ingredient = await _ingredientRepository.GetById(request.Id, cancellationToken);

        if (ingredient == null)
        {
            return Result.Failure(IngredientErrors.NotFound);
        }

        var nameResult = IngredientName.Create(request.Name);
        var descriptionResult = IngredientDescription.Create(request.Description);

        var result = Result.FirstFailureOrSuccess(nameResult, descriptionResult);

        if (result.IsFailure)
            return Result.Failure(result.Error);

        var updateResult = ingredient.UpdateIngredient(nameResult.Value, descriptionResult.Value);

        if (updateResult.IsFailure)
        {
            return Result.Failure(updateResult.Error);
        }

        _ingredientRepository.Update(ingredient);

        return Result.Success();
    }
}
