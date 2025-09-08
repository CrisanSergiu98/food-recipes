using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Users.Queries.Login;

internal sealed class LoginQueryHandler : IQueryHandler<LoginQuery, Result<string>>
{
    public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}