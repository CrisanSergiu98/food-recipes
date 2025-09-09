using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Users.Queries.Login;

public record LoginQuery(string Email, string Password) : IQuery<Result<string>>;