using Auth.Core.Shared.InputModels.Role;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.Role
{
    public class UpdateRoleInputValidator : AbstractValidator<UpdateRoleInput>
    {
        public UpdateRoleInputValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            Include(new BaseRoleInputValidator());
        }
    }
}