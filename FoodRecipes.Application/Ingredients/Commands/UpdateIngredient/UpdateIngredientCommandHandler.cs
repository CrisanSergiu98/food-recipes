using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Errors;
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
        var ingredient = await _ingredientRepository.GetById(request.Id, cancellationToken);

        if (ingredient is null)
            return Result.Failure(IngredientErrors.NotFound);

        bool nameAlreadyExists = await _ingredientRepository.NameExists(request.Name, cancellationToken);

        if (nameAlreadyExists && !(ingredient.Name.Value == request.Name))
            return Result.Failure(IngredientErrors.NameAlreadyExists);

        var name = IngredientName.Create(request.Name);

        if (name.IsFailure)
            return Result.Failure<Guid>(name.Error);

        var description = IngredientDescription.Create(request.Description);

        if (description.IsFailure)
            return Result.Failure<Guid>(description.Error);

        var updateResult = ingredient.UpdateIngredient(name.Value, description.Value);

        if (updateResult.IsFailure)
        {
            return Result.Failure(updateResult.Error);
        }

        await _ingredientRepository.Update(ingredient, cancellationToken);

        return Result.Success();
    }
}
