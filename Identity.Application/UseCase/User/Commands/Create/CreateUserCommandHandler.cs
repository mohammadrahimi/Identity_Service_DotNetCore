

using ErrorOr;
using Identity.Application.Service;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Framework.Core.Bus;

namespace Identity.Application.UseCase.User.Commands.Create;

public class CreateUserCommandHandler : ICommadnHandler<CreateUserCommand, CreateUserCommandResult>
{
    private readonly IAuthenticationService _authenticationService;

    public CreateUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<ErrorOr<CreateUserCommandResult>> Handle(CreateUserCommand command)
    {
        var userResult = await _authenticationService.Register(command);
        if (userResult.IsError)
            return userResult.FirstError;
         
        return new CreateUserCommandResult("success", "User saved.");
    }
}
