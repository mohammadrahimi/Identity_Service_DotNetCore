


using Identity.Framework.Core.Domain;
using System;
using System.Collections.Generic;

namespace Identity.Domain.User.ValueObjects;

public sealed class UserRoleId : ValueObject
{
    public Guid Value { get; }

    //private UserRoleId() { }
    private UserRoleId(Guid value)
    {
        Value = value;
    }
    public static UserRoleId Create(Guid value)
    {
        return new UserRoleId(value);
    }
    public static UserRoleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
