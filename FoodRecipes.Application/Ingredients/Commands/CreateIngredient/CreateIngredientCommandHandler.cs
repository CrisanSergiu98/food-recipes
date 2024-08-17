using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Ingredients.ValueObjects;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.CreateIngredient;
internal class CreateIngredientCommandHandler : ICommandHandler<CreateIngredientCommand, Result>
{
    private readonly IIngredientRepository _ingredientRepository;
    public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }
    public async Task<Result> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
    {
        var name = IngredientName.Create(request.Name);

        if(name.IsFailure)
            return Result.Failure(name.Error);

        var description = IngredientDescription.Create(request.Description);

        if(description.IsFailure)
            return Result.Failure(description.Error);

        var ingredient = Ingredient.Create(
            Guid.NewGuid(),
            name.Value,
            description.Value);

        _ingredientRepository.Insert(ingredient.Value);

        return Result.Success(ingredient.Value);
    }
}
