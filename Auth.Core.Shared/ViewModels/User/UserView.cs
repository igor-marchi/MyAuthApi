using Auth.Core.Shared.ViewModels.Role;
using System.Collections.Generic;

namespace Auth.Core.Shared.ViewModels.User
{
    public class UserView
    {
        public string Email { get; set; }

        public IEnumerable<RoleView> Roles { get; set; }
    }
}