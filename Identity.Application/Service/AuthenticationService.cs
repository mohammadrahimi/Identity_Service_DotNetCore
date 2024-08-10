

using ErrorOr;
using Identity.Application.Errors;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.Commands.User.Login;
using Identity.Domain.Contract.Dto.User;
using Identity.Domain.Role.Enum;
using Identity.Domain.Role.Repository;
using Identity.Domain.User;
using Identity.Domain.User.Repository;
using Identity.Framework.Core.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Application.Service;

public sealed class AuthenticationService : IAuthenticationService
{
    private readonly IUserRepository _IuserRepository;
    private readonly IRoleRepository _IroleRepository;
    private readonly IEncrypter _Iencrypter;
    private readonly IJwtTokenGenerator _IjwtTokenGenerator;

    public AuthenticationService(
        IUserRepository IuserRepository,
        IEncrypter Iencrypter,
        IRoleRepository IroleRepository,
        IJwtTokenGenerator ijwtTokenGenerator)
    {
        _IuserRepository = IuserRepository;
        _Iencrypter = Iencrypter;
        _IroleRepository = IroleRepository;
        _IjwtTokenGenerator = ijwtTokenGenerator;
    }

    public async Task<ErrorOr<string>> Login(LoginUserCommand dtoLogin)
    {
        var _user = await _IuserRepository.GetUser(dtoLogin.country, dtoLogin.mobile);
        if (_user is null)
            return ApplicationErrors.Authentication.UserLoginIsEmpty;

        var _password = _Iencrypter.GetHash(dtoLogin.password, _user.Salt);
        if (_password != _user.Password)
            return ApplicationErrors.Authentication.PasswordLoginNotMatch;

        if (_password == _user.Password)
        {
            var _roles = await _IuserRepository.GetRolesByUserId(_user.Id.Value);
            return _IjwtTokenGenerator.GenerateToken(_user.Id.Value, _roles);
        }

        return ApplicationErrors.Authentication.TokenLoginEmpty;
    }

    public async Task<ErrorOr<Success>> Register(CreateUserCommand dtoUser)
    {
        var _salt = _Iencrypter.GetSalt();
        var _password = _Iencrypter.GetHash(dtoUser.password, _salt);
        var _role = await _IroleRepository.GetByName(EnumeRole.User);

        if (_role is null)
            return ApplicationErrors.Authentication.RegisterNotFoundRole;

        var modifyDtoUser = dtoUser with
        {
            salt = _salt,
            password = _password,
            ListUserRole = new List<UserRoleDto>() { new UserRoleDto(_role.Id.Value) },
        };

        var user = User.Create(modifyDtoUser);
        if (user.IsError)
            return user.FirstError;

        await _IuserRepository.Save(user.Value);

        return Result.Success;
    }
}
