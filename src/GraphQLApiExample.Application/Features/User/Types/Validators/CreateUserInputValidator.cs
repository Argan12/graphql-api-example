using FluentValidation;
using GraphQLApiExample.Application.Features.User.Types.Inputs;

namespace GraphQLApiExample.Application.Features.User.Types.Validators
{
    public class CreateUserInputValidator : AbstractValidator<CreateUserInput>
    {
        public CreateUserInputValidator() 
        {
            RuleFor(x => x.Pseudo)
                .NotEmpty().WithMessage("Pseudo is required.");

            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Mail is required")
                .EmailAddress().WithMessage("Mail is invalid");
        }
    }
}
