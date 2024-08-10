
using ErrorOr;


namespace Identity.Domain.User.Errors;

public static partial class DomainErrors
{
    public static class Address
    {
        public static Error CityIsEmpty => Error.Unexpected(
          code: "City.Empty",
          description: "City is empty");

        public static Error CodePostiIsEmpty => Error.Unexpected(
           code: "CodePosti.Empty",
           description: "CodePosti is empty");
    }
}
