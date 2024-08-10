



using Identity.Framework.Core.Bus;
using System;

namespace Identity.Domain.Contract.Event.Role;

public class RoleCreatedEvent : IDomainEvent
{
    public RoleCreatedEvent(
        Guid roleId,
        string roleName)
    {
        this.roleId = roleId;
        this.roleName = roleName;
    }

    public Guid roleId { get; private set; }
    public string roleName { get; private set; }

}
