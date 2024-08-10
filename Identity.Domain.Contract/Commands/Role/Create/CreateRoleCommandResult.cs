

using Identity.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.Role.Create;

public record CreateRoleCommandResult(string state, string message) : ICommandResult;
