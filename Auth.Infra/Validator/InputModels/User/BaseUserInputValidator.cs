using Auth.Core.Shared.InputModels.User;
using Auth.Infra.Validator.InputModels.Role;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.User
{
    public class BaseUserInputValidator : AbstractValidator<BaseUserInput>
    {
        public BaseUserInputValidator()
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

            RuleForEach(x => x.Roles)
                .SetValidator(new RoleReferenceInputValidator());
        }
    }
}