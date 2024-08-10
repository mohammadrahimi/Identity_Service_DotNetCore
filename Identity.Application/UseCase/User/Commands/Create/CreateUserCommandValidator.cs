

using FluentValidation;
using Identity.Domain.Contract.Commands.User.Create;
using Identity.Domain.Contract.Dto.User;

namespace Identity.Application.UseCase.User.Commands.Create;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.firstname).NotEmpty().Length(2, 50).WithMessage("Please  Enter a first name"); 
        RuleFor(x => x.lastname).NotEmpty().Length(2, 50).WithMessage("Please Enter a last name"); 
        RuleFor(x => x.mobileCountry).NotEmpty().MaximumLength(3).WithMessage("Please Enter a mobile country  "); 
        RuleFor(x => x.mobileNumber).NotEmpty().MaximumLength(10).WithMessage("Please Enter a mobile number  ");
        RuleFor(x => x.password).NotEmpty().WithMessage("Please Enter a password ");
        RuleFor(x => x.city).NotEmpty().MaximumLength(100).WithMessage("Please Enter a city Address ");
        RuleFor(x => x.codeposti).NotEmpty().MaximumLength(150).WithMessage("Please Enter a codeposti Address ");

       // RuleFor(x => x.ListUserRole).NotNull().SetValidator(new UserRoleValidator());

    }
}
public class UserRoleValidator : AbstractValidator<List<UserRoleDto>>
{
    public UserRoleValidator()
    {
         
        RuleFor(x => x)
               .ForEach(x =>
               {
                   x.ChildRules(permission =>
                   {
                       permission.CascadeMode = CascadeMode.Stop;
                       permission.RuleFor(y => y.RoleId).NotNull().WithMessage("Please Enter a RoleId ");
                   });
               });
    }
}
