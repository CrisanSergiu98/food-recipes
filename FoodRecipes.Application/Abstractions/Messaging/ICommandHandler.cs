using MediatR;

namespace FoodRecipes.Application.Abstractions.Messaging;

// Handles commands that don't return a response.
public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : ICommand
{
    // Handles the command asynchronously.
    // Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
}

// Handles commands that return a response.
public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    // Handles the command asynchronously and returns a response.
    // Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
}
