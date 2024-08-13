using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Ingredients;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Ingredients.Commands.CreateIngredient;
internal class CreateIngredientCommandHandler : ICommandHandler<CreateIngreduebtCommand, Result>
{
    public async Task<Result> Handle(CreateIngreduebtCommand request, CancellationToken cancellationToken)
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

        return Result.Success(ingredient);
    }
}
