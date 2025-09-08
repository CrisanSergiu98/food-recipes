using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Users.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}