using Auth.Core.Shared.InputModels.User;
using FluentValidation;

namespace Auth.Infra.Validator.InputModels.User
{
    public class NewUserInputValidator : AbstractValidator<NewUserInput>
    {
        public NewUserInputValidator()
        {
            Include(new BaseUserInputValidator());
        }
    }
}