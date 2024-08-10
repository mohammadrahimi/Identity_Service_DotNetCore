

using Identity.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.Role.Create;

public record CreateRoleCommand(
   string name  ) : ICommand;
