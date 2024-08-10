
using ErrorOr;


namespace Identity.Domain.User.Errors;


public static partial class DomainErrors
{
    public static class User
    {
        public static Error FirstNameIsEmpty => Error.Unexpected(
            code: "FirstName.Empty",
            description: "FirstName customer is empty");

        public static Error LastNameIsEmpty => Error.Unexpected(
           code: "LastName.Empty",
           description: "LastName customer is empty");

        public static Error PasswordIsEmpty => Error.Unexpected(
          code: "Password.Empty",
          description: "Password User is empty");
        

        public static Error RoleIsNull => Error.Unexpected(
          code: "Role.Null",
          description: "List role is null");
    }

}


