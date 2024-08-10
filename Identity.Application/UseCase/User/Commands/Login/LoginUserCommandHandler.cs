

using ErrorOr;
using Identity.Application.Service;
using Identity.Domain.Contract.Commands.User.Login;
using Identity.Framework.Core.Bus;

namespace Identity.Application.UseCase.User.Commands.Login;

public class LoginUserCommandHandler : ICommadnHandler<LoginUserCommand, LoginUserCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<ErrorOr<LoginUserCommandResult>> Handle(LoginUserCommand command)
    {
        var loginResult = await _authenticationService.Login(command);
        if (loginResult.IsError)
            return loginResult.FirstError;

        return new LoginUserCommandResult(loginResult.Value);
    }
}
