

using ErrorOr;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.Commands.User.Login;
using System.Threading.Tasks;

namespace Identity.Application.Service;

public interface IAuthenticationService
{
    Task<ErrorOr<string>> Login(LoginUserCommand dto);
    Task<ErrorOr<Success>> Register(CreateUserCommand dto);

}
