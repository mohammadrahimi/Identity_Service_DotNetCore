



using Identity.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.User.Create;

public record CreateUserCommandResult(string state, string message) : ICommandResult;
