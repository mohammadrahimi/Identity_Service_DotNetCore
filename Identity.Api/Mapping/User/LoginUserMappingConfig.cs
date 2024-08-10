using Identity.Domain.Contract.Commands.User.Login;
using Identity.Domain.Contract.ViewModel.Authentication;
using Mapster;

namespace Identity.Api.Mapping.User;

public class LoginUserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginViewModel, LoginUserCommand>()
            .Map(dest => dest.mobile, src => src.mobile)
            .Map(dest => dest.country, src => src.countery)
            .Map(dest => dest.password, src => src.password);
    }
}
