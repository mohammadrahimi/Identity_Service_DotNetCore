
using ErrorOr;


namespace Identity.Application.Errors;

public static partial class ApplicationErrors
{
    public static class Authentication
    {
        public static Error TokenLoginEmpty => Error.Unexpected(
           code: "TokenLogin.Empty",
           description: "Token Login is empty");

        public static Error UserLoginIsEmpty => Error.Unexpected(
           code: "UserLogin.Empty",
           description: "User Login is empty");

        public static Error PasswordLoginNotMatch => Error.Unexpected(
            code: "PasswordLogin.NotMatch",
            description: "Password Login Not Match ");

        public static Error RegisterNotFoundRole => Error.Unexpected(
            code: "Register.NotRole",
            description: "Register Not Found Role "); 

    }
}
