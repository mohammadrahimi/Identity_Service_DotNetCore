
using ErrorOr;



namespace Identity.Domain.User.Errors;

public static partial class DomainErrors
{
    public static class Mobile
    {
        public static Error MobileNumberMaxlength => Error.Failure(
            code: "MobileNumber.MaxLength",
            description: "Mobile number is maxlength");

        public static Error MobileCountryMaxlength => Error.Failure(
           code: "MobileCountry.MaxLength",
           description: "Mobile country is maxlength");

        public static Error MobileIsEmpty => Error.Unexpected(
           code: "Mobile.Empty",
           description: "Mobile number is empty");
    }
}
