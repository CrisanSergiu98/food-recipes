using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Application.Abstractions.Security;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Users;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Application.Users.Commands.Register;

internal sealed class RegisterCommandHandler : ICommandHandler<RegisterCommand, Result<string>>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtTokenService _tokenService;
    public RegisterCommandHandler(
        IUserRepository userRepository,
        IJwtTokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }
    public async Task<Result<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var userEmail = UserEmail.Create(request.Email);

        if (userEmail.IsFailure)
            return Result.Failure<string>(userEmail.Error);

        var userResult = await _userRepository.GetByEmail(userEmail.Value, cancellationToken);

        if (userResult is not null)
            return Result.Failure<string>(UserErrors.EmailAlreadyUsed);

        // salt + cost embedded automatically
        var userPassword = UserPassword.Create(BCrypt.Net.BCrypt.HashPassword(request.Password, workFactor: 12));

        if (userPassword.IsFailure)
            return Result.Failure<string>(userPassword.Error);

        var user = User.Create(
            Guid.NewGuid(),
            userEmail.Value,
            userPassword.Value
            );

        await _userRepository.Insert(user.Value, cancellationToken);

        return _tokenService.GenerateToken(user.Value.Id, user.Value.Email.Value);
    }
}