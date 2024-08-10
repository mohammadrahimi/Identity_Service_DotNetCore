

using ErrorOr;
using Identity.Domain.Role.ValueObjects;
using Identity.Domain.User.Errors;
using Identity.Domain.User.ValueObjects;
using Identity.Framework.Core.Domain;


namespace Identity.Domain.User.Entites;

public class UserRole : Entity<UserRoleId>
{
    private UserRole() : base(UserRoleId.CreateUnique()) { }

    public RoleId RoleId { get; private set; }

    private UserRole(UserRoleId userRoleId, RoleId roleId)
           : base(userRoleId)
    {
        RoleId = roleId;
    }

    public static ErrorOr<UserRole> Create(RoleId roleId)
    {
        if (roleId is null)
            return DomainErrors.UserRole.RoleIsNull;

        return new UserRole(
            UserRoleId.CreateUnique(),
            roleId);
    }
}
