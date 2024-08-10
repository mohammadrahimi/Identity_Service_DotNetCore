


using Identity.Framework.Core.Domain;
using System;
using System.Collections.Generic;

namespace Identity.Domain.User.ValueObjects;

public sealed class UserId : ValueObject
{
    public Guid Value { get; }

    //private UserId() { }
    private UserId(Guid value)
    {
        Value = value;
    }
    public static UserId Create(Guid value)
    {
        return new UserId(value);
    }
    public static UserId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
