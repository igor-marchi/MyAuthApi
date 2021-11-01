using Auth.Core.Shared.InputModels.User;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.User
{
    public class AuthUserInputValidator : AbstractValidator<AuthUserInput>
    {
        public AuthUserInputValidator()
        {
            RuleFor(x => x.Email)
             .NotNull()
             .NotEmpty()
             .EmailAddress()
             .MaximumLength(200);

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}