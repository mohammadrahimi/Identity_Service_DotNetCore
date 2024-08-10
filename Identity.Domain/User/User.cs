


using ErrorOr;
using FluentValidation;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.Event.User;
using Identity.Domain.Role.ValueObjects;
using Identity.Domain.User.Entites;
using Identity.Domain.User.Errors;
using Identity.Domain.User.ValueObjects;
using Identity.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Identity.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    private User() : base(UserId.CreateUnique()) { }

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Password { get; private set; }
    public string Salt { get; private set; }
    public Mobile Mobile { get; private set; }
    public Address Address { get; private set; }
    public DateTime CreateDateTime { get; }

    private readonly static List<UserRole> _userroles = new();
    public IReadOnlyCollection<UserRole> UserRoles => _userroles;

    private User(UserId userId,
         string firstname,
         string lastname,
         string password,
         string salt,
         Mobile mobile,
         Address address,
         DateTime createdatetime)
         : base(userId)
    {
        FirstName = firstname;
        LastName = lastname;
        Password = password;
        Salt = salt;
        Address = address;
        Mobile = mobile;
        CreateDateTime = createdatetime;
    }

    public static ErrorOr<User> Create(CreateUserCommand command)
    {
        var _mobile = Mobile.Create(command.mobileNumber, command.mobileCountry);
        var _address = Address.Create(command.city, command.codeposti);

        if (string.IsNullOrWhiteSpace(command.firstname))
            return DomainErrors.User.FirstNameIsEmpty;
        if (string.IsNullOrWhiteSpace(command.lastname))
            return DomainErrors.User.LastNameIsEmpty;
        if (string.IsNullOrWhiteSpace(command.password))
            return DomainErrors.User.PasswordIsEmpty;
        if (_mobile.IsError)
            return _mobile.FirstError;
        if (_address.IsError)
            return _address.FirstError;
        if (command.ListUserRole is null || !command.ListUserRole.Any())
            return DomainErrors.User.RoleIsNull;

        var _listRoleIds = new List<Guid>();
        command.ListUserRole.ForEach(userRole => { _listRoleIds.Add(userRole.RoleId); AddItemUserRole(RoleId.Create(userRole.RoleId)); });

        var user = new User(
            UserId.CreateUnique(),
            command.firstname,
            command.lastname,
            command.password,
            command.salt,
            _mobile.Value,
            _address.Value,
            DateTime.UtcNow);

        user.AddEventChanges(new UserCreatedEvent(
                user.Id.Value,
                user.FirstName,
                user.LastName,
                $"{user.Mobile.Country}-{user.Mobile.Number}",
                $"{user.Address.City}-{user.Address.CodePosti}",
                _listRoleIds
            ));

        return user;
    }
    public static ErrorOr<Success> AddItemUserRole(RoleId roleId)
    {
        var userRoleResult = UserRole.Create(roleId);

        _userroles.Add(userRoleResult.Value);
        return Result.Success;
    }
    public void RemoveItemUserRole(RoleId roleId)
    {
        var item = _userroles.Find(x => x.RoleId == roleId);
        if (item is not null)
            _userroles.Remove(item);
    }

}
