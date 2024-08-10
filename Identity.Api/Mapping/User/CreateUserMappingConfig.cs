
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.ViewModel.User;
using Mapster;

namespace Identity.Api.Mapping.User;

public class CreateUserMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateUserViewModel, CreateUserCommand>()
            .Map(dest => dest.firstname, src => src.fname)
            .Map(dest => dest.lastname, src => src.lname)
            .Map(dest => dest.mobileCountry, src => src.mCountry)
            .Map(dest => dest.mobileNumber, src => src.mNumber)
            .Map(dest => dest.city, src => src.city)
            .Map(dest => dest.codeposti, src => src.codeposti)
            .Map(dest => dest.password, src => src.password);
    }
}

