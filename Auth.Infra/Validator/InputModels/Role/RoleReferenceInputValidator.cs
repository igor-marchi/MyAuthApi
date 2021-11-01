using Auth.Core.Shared.InputModels.Role;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.Role
{
    public class RoleReferenceInputValidator : AbstractValidator<RoleReferenceInput>
    {
        public RoleReferenceInputValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0);
        }
    }
}