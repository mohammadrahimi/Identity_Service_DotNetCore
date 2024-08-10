

using FluentValidation;
using Identity.Domain.Contract.Commands.User.Login;

namespace Identity.Application.UseCase.User.Commands.Login;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.country).NotEmpty().Length(2, 4).WithMessage("Please  Enter a mobile country "); 
        RuleFor(x => x.mobile).NotEmpty().MaximumLength(10).WithMessage("Please Enter a mobile number  ");
        RuleFor(x => x.password).NotEmpty().WithMessage("Please Enter a password ");
    }
}
