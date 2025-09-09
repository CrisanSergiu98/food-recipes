using FoodRecipes.Application.Abstractions.Messaging;
using FoodRecipes.Domain.Shared;

namespace FoodRecipes.Application.Users.Commands.Register;

public record RegisterCommand(string Email, string Password) : ICommand<Result<string>>;