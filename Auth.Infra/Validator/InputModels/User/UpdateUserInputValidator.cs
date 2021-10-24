using Auth.Core.Shared.InputModels.User;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.User
{
    public class UpdateUserInputValidator : AbstractValidator<UpdateUserInput>
    {
        public UpdateUserInputValidator()
        {
            Include(new BaseUserInputValidator());
        }
    }
}