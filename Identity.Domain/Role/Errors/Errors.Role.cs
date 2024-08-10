using ErrorOr;


namespace Identity.Domain.Role.Errors;

public static partial class DomainErrors
{
    public static class Role
    {
        public static Error RoleNameIsEmpty => Error.Unexpected(
          code: "RoleName.Empty",
          description: "RoleName is empty");
    }
}
