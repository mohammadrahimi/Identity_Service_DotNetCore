


using ErrorOr;
using Identity.Domain.Contract.Commands.Role.Create;
using Identity.Domain.Role.Repository;
using Identity.Framework.Core.Bus;
using System.Threading.Tasks;

namespace Identity.Application.UseCase.Role.Commands.Create;

public class CreateRoleCommandHandler : ICommadnHandler<CreateRoleCommand, CreateRoleCommandResult>
{
    private readonly IRoleRepository _roleRepository;

    public CreateRoleCommandHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<ErrorOr<CreateRoleCommandResult>> Handle(CreateRoleCommand command)
    {
        var roleResult = Identity.Domain.Role.Role.Create(command);
        if (roleResult.IsError)
            return roleResult.FirstError;

        await _roleRepository.Save(roleResult.Value!);

        return new CreateRoleCommandResult("success", "Role Saved.");
    }
}

