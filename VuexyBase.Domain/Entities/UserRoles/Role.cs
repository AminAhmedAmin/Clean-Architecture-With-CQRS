using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Domain.Entities.UserRoles
{
    public class Role: IdentityRole<string>
    {
        public Role(string name, bool isAdmin)
        {
            base.Name = name;
            base.NormalizedName = name.ToUpper(); // 👈 should be explicitly set
            IsAdministrator = isAdmin;
            Id = Guid.NewGuid().ToString(); // 👈 explicitly generate Id (if seeding manually)
        }

        public bool IsAdministrator { get; set; }
        public virtual ICollection<ApplicationDbUser> Users { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        public Role() { } // Required by EF Core
    }
}
