using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllUnits;

internal class GetAllUnitsQueryHandler : IQueryHandler<GetAllUnitsQuery, Result<string[]>>
{
    public async Task<Result<string[]>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        return Result.Success(Enum.GetNames(typeof(Unit)));
    }
}
