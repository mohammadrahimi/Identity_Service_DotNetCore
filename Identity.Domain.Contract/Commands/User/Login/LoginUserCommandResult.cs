



using Identity.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.User.Login;

public record LoginUserCommandResult(string token) : ICommandResult;
