using System.Collections.Generic;

namespace Auth.Core.Domain
{
    public class Role
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}