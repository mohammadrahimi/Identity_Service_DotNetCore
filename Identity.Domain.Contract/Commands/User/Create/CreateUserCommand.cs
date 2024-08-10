
using Identity.Domain.Contract.Dto.User;
using Identity.Framework.Core.Bus;
using System.Collections.Generic;

namespace Identity.Domain.Contract.Commands.User.Create;

public record CreateUserCommand(
    string firstname,
    string lastname,
    string password,
    string salt,
    string mobileNumber,
    string mobileCountry,
    string city,
    string codeposti,
    List<UserRoleDto> ListUserRole) : ICommand;
 
