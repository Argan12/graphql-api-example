using FluentValidation.TestHelper;
using GraphQLApiExample.Application.Features.User.Types.Inputs;
using GraphQLApiExample.Application.Features.User.Types.Validators;

namespace GraphQLApiExample.Application.Tests.Validators
{
    public class CreateUserInputValidatorTests
    {
        private readonly CreateUserInputValidator _validator;

        public CreateUserInputValidatorTests()
        {
            _validator = new CreateUserInputValidator();
        }

        [Fact]
        public void CreateUserInputValidator_ShouldThrowIfPseudoIsEmpty()
        {
            var input = new CreateUserInput
            {
                Mail = "john.doe@gmail.com"
            };

            var res = _validator.TestValidate(input);
            res.ShouldHaveValidationErrorFor(x => x.Pseudo)
                .WithErrorMessage("Pseudo is required.");
        }

        [Fact]
        public void CreateUserInputValidator_ShouldThrowIfMailIsEmpty()
        {
            var input = new CreateUserInput
            {
                Pseudo = "John Doe"
            };

            var res = _validator.TestValidate(input);
            res.ShouldHaveValidationErrorFor(x => x.Mail)
                .WithErrorMessage("Mail is required");
        }

        [Fact]
        public void CreateUserInputValidator_ShouldThrowIfMailIsInvalid()
        {
            var input = new CreateUserInput
            {
                Pseudo = "John Doe",
                Mail = "johndoe"
            };

            var res = _validator.TestValidate(input);
            res.ShouldHaveValidationErrorFor(x => x.Mail)
                .WithErrorMessage("Mail is invalid");
        }

        [Fact]
        public void CreateUserInputValidator_Ok()
        {
            var input = new CreateUserInput
            {
                Pseudo = "John Doe",
                Mail = "john.doe@gmail.com"
            };

            var res = _validator.TestValidate(input);
            res.ShouldNotHaveValidationErrorFor(x => x.Mail);
            res.ShouldNotHaveValidationErrorFor(x => x.Pseudo);
        }
    }
}
