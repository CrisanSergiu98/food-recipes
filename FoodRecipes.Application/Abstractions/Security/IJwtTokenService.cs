namespace FoodRecipes.Application.Abstractions.Security;

public interface IJwtTokenService
{
    string GenerateToken(Guid userId, string email);
}