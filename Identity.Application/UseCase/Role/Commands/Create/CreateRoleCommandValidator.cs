
using FluentValidation;
using Identity.Domain.Contract.Commands.Role.Create;

namespace Identity.Application.UseCase.Role.Commands.Create;


public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
{
    public CreateRoleCommandValidator()
    {
        RuleFor(x => x.name).NotEmpty().Length(2, 50).WithMessage("Please  Enter a Role name");

    }
}
