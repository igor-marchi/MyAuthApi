using Auth.Core.Shared.InputModels.Role;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.Role
{
    public class BaseRoleInputValidator : AbstractValidator<BaseRoleInput>
    {
        public BaseRoleInputValidator()
        {
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}