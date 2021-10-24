using Auth.Core.Shared.InputModels.Role;
using System.Collections.Generic;

namespace Auth.Core.Shared.InputModels.User
{
    public class BaseUserInput
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<RoleReferenceInput> Roles { get; set; }
    }
}