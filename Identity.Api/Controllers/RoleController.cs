 
using Identity.Domain.Contract.Commands.Role.Create;
using Identity.Domain.Contract.ViewModel.Role;
using Identity.Framework.Core.Bus;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Api.Controllers;

[Route("Role")]
public class RoleController : ApiController
{
    private readonly ICommandBus _commandBus;
    private readonly IMapper _mapper;

    public RoleController(ICommandBus commandBus, IMapper mapper)
    {
        _commandBus = commandBus;
        _mapper = mapper;
    }

    [HttpPost(nameof(CreateRole))]
    public async Task<IActionResult> CreateRole(CreateRoleViewModel request)
    {
        var createRoleCommand = _mapper.Map<CreateRoleCommand>(request);
        var createRoleResult =
            await _commandBus.Send<CreateRoleCommand, CreateRoleCommandResult>(createRoleCommand);

        return createRoleResult.Match(
             roleResult => Ok(roleResult),
             errors => Problem(errors));

    }
}
