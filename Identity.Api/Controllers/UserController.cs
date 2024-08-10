
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.Commands.User.Login;
using Identity.Domain.Contract.ViewModel.Authentication;
using Identity.Domain.Contract.ViewModel.User;
using Identity.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[Route("User")]
public class UserController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IMapper _mapper;

    public UserController(ICommandBus commandBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(Register))]
    public async Task<IActionResult> Register(CreateUserViewModel request)
    {
        var createUserCommand = _mapper.Map<CreateUserCommand>(request);
        var createUserResult =
            await _commandBus.Send<CreateUserCommand, CreateUserCommandResult>(createUserCommand);

        return createUserResult.Match(
             createUser => Ok(createUser),
             errors => Problem(errors));
    }

    [HttpPost(nameof(Login))]
    public async Task<IActionResult> Login(LoginViewModel request)
    {
        var loginUserCommand = _mapper.Map<LoginUserCommand>(request);
        var loginUserResult =
            await _commandBus.Send<LoginUserCommand, LoginUserCommandResult>(loginUserCommand);

        return loginUserResult.Match(
             loginUser => Ok(loginUser),
             errors => Problem(errors));
    }

}

