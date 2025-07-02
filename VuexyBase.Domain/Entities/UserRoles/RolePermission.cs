using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Enums.UserRoles;

namespace VuexyBase.Domain.Entities.UserRoles
{
    public class RolePermission
    {
        public string RoleId { get; set; }
        public virtual Role Role { get; set; }

        public int PermissionId { get; set; }

        public ActionType Action { get; set; }   // e.g., "Read", "Write", "Create"
        public virtual Permission Permission { get; set; }
    }
}
