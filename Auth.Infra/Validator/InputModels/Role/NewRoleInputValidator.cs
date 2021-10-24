using Auth.Core.Shared.InputModels.Role;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.Role
{
    public class NewRoleInputValidator : AbstractValidator<NewRoleInput>
    {
        public NewRoleInputValidator()
        {
            Include(new BaseRoleInputValidator());
        }
    }
}