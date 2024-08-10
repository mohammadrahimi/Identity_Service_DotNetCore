

using Identity.Domain.Contract.Commands.Role.Create;
using Identity.Domain.Contract.ViewModel.Role;
using Mapster;

namespace Identity.Api.Mapping.Role;

public class CreateRoleMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateRoleViewModel, CreateRoleCommand>()
             .Map(dest => dest.name, src => src.name);
    }
}
