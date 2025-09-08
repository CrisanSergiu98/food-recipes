using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Application.Users.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<string>>
{
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        // Check email exists
        var userEmail = UserEmail.Create(request.Email);

        if (userEmail.IsFailure)
            return Result.Failure<string>(userEmail.Error);
        // salt + cost embedded automatically
        var userPassword = UserPassword.Create(BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 12));

        if (userPassword.IsFailure)
            return Result.Failure<string>(userPassword.Error);

        var user = User.Create(
            Guid.NewGuid(),
            userEmail.Value,
            userPassword.Value
            );

        // Persist the User
        // Return Success with token
        
        throw new NotImplementedException();
    }
}