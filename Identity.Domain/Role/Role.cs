

using ErrorOr;
using Identity.Domain.Contract.Commands.Role.Create;
using Identity.Domain.Contract.Event.Role;
using Identity.Domain.Role.Errors;
using Identity.Domain.Role.ValueObjects;
using Identity.Framework.Core.Domain;

namespace Identity.Domain.Role;

public sealed class Role : AggregateRoot<RoleId>
{
    private Role() : base(RoleId.CreateUnique()) { }
    public string Name { get; private set; }

    private Role(RoleId roleId, string name)
          : base(roleId)
    {
        Name = name;
    }

    public static ErrorOr<Role> Create(CreateRoleCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.name))
            return DomainErrors.Role.RoleNameIsEmpty;
         
        var role = new Role(
            RoleId.CreateUnique(),
            command.name);

        role.AddEventChanges(new RoleCreatedEvent(
            role.Id.Value,
            role.Name
            ));

        return role;
    }
}
