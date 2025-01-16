using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Recipes.Enums;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Recipes.Queries.GetAllUnits;

// Query handler for getting all units
internal class GetAllUnitsQueryHandler : IQueryHandler<GetAllUnitsQuery, Result<string[]>>
{
    // Handles the get all units query
    public async Task<Result<string[]>> Handle(GetAllUnitsQuery request, CancellationToken cancellationToken)
    {
        // Retrieve all unit names from the Unit enum
        return Result.Success(Enum.GetNames(typeof(Unit)));
    }
}
