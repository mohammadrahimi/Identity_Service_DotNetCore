


using Identity.Domain.Role.Repository;
using Identity.Domain.User.Repository;
using Identity.Persistence.EF.Context;
using Identity.Persistence.EF.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Persistence.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
          .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<IdentityDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("IdentityConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        return services;
    }

}
