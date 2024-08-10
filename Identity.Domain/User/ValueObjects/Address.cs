

using ErrorOr;
using Identity.Domain.User.Errors;
using Identity.Framework.Core.Domain;
using System.Collections.Generic;

namespace Identity.Domain.User.ValueObjects;

public sealed class Address : ValueObject
{

    public string City { get; private set; }
    public string CodePosti { get; private set; }

    // private Address() { }
    private Address(string city, string codePosti)
    {
        City = city;
        CodePosti = codePosti;
    }

    public static ErrorOr<Address> Create(string city, string codePosti)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            return DomainErrors.Address.CityIsEmpty;
        }

        if (string.IsNullOrWhiteSpace(codePosti))
        {
            return DomainErrors.Address.CodePostiIsEmpty;
        }

        return new Address(city, codePosti);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return City;
        yield return CodePosti;
    }
}
