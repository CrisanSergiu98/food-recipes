using FoodRecipes.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace FoodRecipes.Application.Abstractions.Messaging
{
    /// <summary>
    /// Defines a handler for a command in the CQRS (Command Query Responsibility Segregation) pattern.
    /// This handler processes commands that do not return a response.
    /// </summary>
    /// <typeparam name="TCommand">The type of command to be handled. Must implement <see cref="ICommand"/>.</typeparam>
    public interface ICommandHandler<in TCommand>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command asynchronously.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Result"/> indicating the outcome of the command handling.</returns>
        Task<Result> Handle(TCommand command, CancellationToken cancellationToken);
    }

    /// <summary>
    /// Defines a handler for a command in the CQRS (Command Query Responsibility Segregation) pattern.
    /// This handler processes commands that return a response.
    /// </summary>
    /// <typeparam name="TCommand">The type of command to be handled. Must implement <see cref="ICommand"/>.</typeparam>
    /// <typeparam name="TResponse">The type of response returned by the command handler.</typeparam>
    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand
    {
        /// <summary>
        /// Handles the specified command asynchronously and returns a response.
        /// </summary>
        /// <param name="command">The command to handle.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="Result{TResponse}"/> indicating the outcome of the command handling along with the response.</returns>
        Task<Result<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
    }
}
