
 
using ErrorOr;
using Identity.Domain.User.Errors;
using Identity.Framework.Core.Domain;
 
using System.Collections.Generic;

namespace Identity.Domain.User.ValueObjects;

public sealed class Mobile : ValueObject
{
    private const int MaxlengthNumber = 10;
    private const int MaxlengthCountry = 3;

    public string Number { get; private set; }
    public string Country { get; private set; }

    // private Mobile() { }
    private Mobile(string number, string country)
    {
        Number = number;
        Country = country;
    }

    public static ErrorOr<Mobile> Create(string number, string country)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            return DomainErrors.Mobile.MobileIsEmpty;
        }
        if (number.Length > MaxlengthNumber)
        {
            return DomainErrors.Mobile.MobileNumberMaxlength;
        }
        if (string.IsNullOrWhiteSpace(country))
        {
            return DomainErrors.Mobile.MobileIsEmpty;
        }
        if (country.Length > MaxlengthCountry)
        {
            return DomainErrors.Mobile.MobileCountryMaxlength;
        }
        return new Mobile(number, country);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Number;
        yield return Country;
    }
}
