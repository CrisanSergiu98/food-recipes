using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Application.Abstractions.Repositories;
using FoodRecipes.Application.Abstractions.Security;
using FoodRecipes.Domain.Errors;
using FoodRecipes.Domain.Shared;
using FoodRecipes.Domain.Users.ValueObjects;

namespace FoodRecipes.Application.Users.Queries.Login;

internal sealed class LoginQueryHandler : IQueryHandler<LoginQuery, Result<string>>
{
    private readonly IJwtTokenService _tokenService;
    private readonly IUserRepository _userRepository;
    public LoginQueryHandler(
        IUserRepository userRepository,
        IJwtTokenService tokenService)
    {
        _tokenService = tokenService;
        _userRepository = userRepository;
    }
    public async Task<Result<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var userEmail = UserEmail.Create(request.Email);

        if (userEmail.IsFailure)
            return Result.Failure<string>(userEmail.Error);

        var user = await _userRepository.GetByEmail(userEmail.Value, cancellationToken);

        if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password.Value))
            return Result.Failure<string>(UserErrors.LoginDetailsIncorrect);

        return _tokenService.GenerateToken(user.Id, user.Email.Value);
    }
}