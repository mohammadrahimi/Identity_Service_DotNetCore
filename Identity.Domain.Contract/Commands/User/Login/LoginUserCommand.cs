
using Identity.Framework.Core.Bus;

namespace Identity.Domain.Contract.Commands.User.Login;

public record LoginUserCommand(string country, string mobile, string password) : ICommand;

