
using ErrorOr;


namespace Identity.Domain.User.Errors;


public static partial class DomainErrors
{
    public static class UserRole
    {
        public static Error RoleIsNull => Error.Unexpected(
          code: "Role.Null",
          description: "List role is null");
    }

}


