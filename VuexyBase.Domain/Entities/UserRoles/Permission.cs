using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Entities.UserRoles
{
    public class Permission
    {
        public int Id { get; set; }
        public string Category { get; set; } // e.g., "User Management"
        public string Action { get; set; }   // e.g., "Read", "Write", "Create"

        public ICollection<RolePermission> RolePermissions { get; set; }
    }
}
