

using FluentValidation;
using Identity.Domain.Contract.Commands.Role.Create;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Framework.Core.Bus;
using Identity.Framework.Core.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Identity.Framework.Core.Utility;
using Identity.Application.Service;
using Identity.Application.UseCase.User.Commands.Create;
using Identity.Domain.Contract.Commands.User.Login;
using Identity.Application.UseCase.User.Commands.Login;
using Identity.Application.UseCase.Role.Commands.Create;

namespace Identity.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
         

        services.AddScoped<ICommadnHandler<CreateUserCommand, CreateUserCommandResult>, CreateUserCommandHandler>();
        services.AddScoped<ICommadnHandler<LoginUserCommand, LoginUserCommandResult>, LoginUserCommandHandler>();
        services.AddScoped<ICommadnHandler<CreateRoleCommand, CreateRoleCommandResult>, CreateRoleCommandHandler>();

        services.AddScoped<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
        services.AddScoped<IValidator<CreateRoleCommand>, CreateRoleCommandValidator>();
        services.AddScoped<IValidator<LoginUserCommand>, LoginUserCommandValidator>();

        services.AddScoped<IEncrypter, Encrypter>();
        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
