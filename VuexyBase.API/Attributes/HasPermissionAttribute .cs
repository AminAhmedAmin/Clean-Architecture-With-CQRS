using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Enums.UserRoles;
using Microsoft.EntityFrameworkCore;

namespace VuexyBase.API.Attributes
{
    public class HasPermissionAttribute : Attribute, IAuthorizationFilter
    {
        private readonly string _permissionName;
        private readonly ActionType _action;

        public HasPermissionAttribute(string permissionName, ActionType action)
        {
            _permissionName = permissionName;
            _action = action;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Result = new ForbidResult();
                return;
            }

            var userId = user.FindFirst("sub")?.Value ?? user.FindFirst("UserId")?.Value;
            if (string.IsNullOrEmpty(userId))
            {
                context.Result = new ForbidResult();
                return;
            }

            var db = context.HttpContext.RequestServices.GetRequiredService<ApplicationDbContext>();

            // جلب RoleId للمستخدم
            var roleId = db.Users
                .Where(u => u.Id == userId)
                .Select(u => u.RoleId)
                .FirstOrDefault();

            if (string.IsNullOrEmpty(roleId))
            {
                context.Result = new ForbidResult();
                return;
            }

            // تحقق من وجود الصلاحية المرتبطة بالاسم ونوع الإجراء
            var hasPermission = db.RolePermissions
                .Include(rp => rp.Permission)
                .Any(rp =>
                    rp.RoleId == roleId &&
                    rp.Permission.Category == _permissionName &&
                    rp.Action == _action);

            if (!hasPermission)
            {
                context.Result = new ForbidResult();
            }
        }
    }

}
