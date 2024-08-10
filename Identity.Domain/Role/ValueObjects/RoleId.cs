

using Identity.Framework.Core.Domain;
using System;
 
using System.Collections.Generic;

namespace Identity.Domain.Role.ValueObjects;
 
 

public sealed class RoleId : ValueObject
{
    public Guid Value { get; }

    //private RoleId() { }
    private RoleId(Guid value)
    {
        Value = value;
    }
    public static RoleId Create(Guid value)
    {
        return new RoleId(value);
    }
    public static RoleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}

