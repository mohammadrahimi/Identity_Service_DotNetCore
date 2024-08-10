
using Identity.Framework.Core.Bus;
using System;
using System.Collections.Generic;

namespace Identity.Domain.Contract.Event.User;

public class UserCreatedEvent : IDomainEvent
{
    public UserCreatedEvent(Guid customerId,
        string firstName,
        string lastName,
        string mobile,
        string address,
        List<Guid> roleIds)
    {
        CustomerId = customerId;
        FirstName = firstName;
        LastName = lastName;
        Mobile = mobile;
        Address = address;
        RoleIds = roleIds;
    }

    public Guid CustomerId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Mobile { get; private set; }
    public string Address { get; private set; }
    public List<Guid> RoleIds { get; private set; }

}

