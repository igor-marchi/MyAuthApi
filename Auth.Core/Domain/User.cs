using System.Collections.Generic;

namespace Auth.Core.Domain
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public IEnumerable<Role> Roles { get; set; }
    }
}