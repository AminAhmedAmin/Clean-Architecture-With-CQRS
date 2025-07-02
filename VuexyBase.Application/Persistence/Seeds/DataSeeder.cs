using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Entities.UserRoles;
using VuexyBase.Domain.Enums.Identities;
using VuexyBase.Domain.Enums.UserRoles;

namespace VuexyBase.Application.Persistence.Seeds
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;
      //  private readonly RoleManager<IdentityRole> _roleManager;
        private readonly RoleManager<Role> _roleManager;

        public DataSeeder(ApplicationDbContext context, UserManager<ApplicationDbUser> userManager, RoleManager<Role> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await SeedRolesAsync();
                await SeedUsersAsync();
                await SeedAppInfoAsync();
                await SeedSettingsAsync();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
        }

        private async Task SeedRolesAsync()
        {
            // Seed roles only if they don't exist
            foreach (var roleName in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    var isAdmin = roleName.Equals("Admin", StringComparison.OrdinalIgnoreCase);
                    var role = new Role(roleName, isAdmin);
                    await _roleManager.CreateAsync(role);
                }
            }
        }

        private async Task SeedPermissionsAsync()
        {
            // 1. Seed permissions if they don’t exist
            if (!_context.Permissions.Any())
            {
                _context.Permissions.AddRange(DefaultSeed.Seedingpermissions());
                await _context.SaveChangesAsync();
            }
            var managerRole = await _roleManager.FindByNameAsync(Roles.Manager.ToString());
            if (managerRole == null) return;

            var allPermissions = await _context.Permissions.ToListAsync();

            foreach (var permission in allPermissions)
            {
                foreach (ActionType action in Enum.GetValues(typeof(ActionType)))
                {
                    bool exists = await _context.RolePermissions.AnyAsync(rp =>
                        rp.RoleId == managerRole.Id &&
                        rp.PermissionId == permission.Id &&
                        rp.Action == action);

                    if (!exists)
                    {
                        _context.RolePermissions.Add(new RolePermission
                        {
                            RoleId = managerRole.Id,
                            PermissionId = permission.Id,
                            Action = action
                        });
                    }
                }
            }
            await _context.SaveChangesAsync();
        }


        private async Task SeedUsersAsync()
        {
            foreach (var user in DefaultSeed.SeedingUsers())
            {
                // Seed users only if they don't exist
                if (!await _context.Users.AnyAsync(x => x.Email == user.Email!))
                {
                    await _userManager.CreateAsync(user, "123456");
                    await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                }
            }
            foreach (var user in DefaultSeed.SeedingUsers())
            {
                if (!await _context.Users.AnyAsync(x => x.Email == user.Email))
                {
                    await _userManager.CreateAsync(user, "123456");

                    // Assign the appropriate role (case-insensitive)
                    //var roleName = user.Role ?? Roles.Admin.ToString(); // fallback if Role is null
                    //if (Enum.TryParse<Roles>(roleName, true, out var role))
                    //{
                    //    await _userManager.AddToRoleAsync(user, role.ToString());
                    //}
                }
            }
        }

        private async Task SeedAppInfoAsync()
        {
            if (!await _context.AppInfos.AnyAsync())
            {
                await _context.AppInfos.AddAsync(DefaultSeed.SeedingAppInfos());
            }
        }

        private async Task SeedSettingsAsync()
        {
            if (!await _context.Settings.AnyAsync())
            {
                await _context.Settings.AddAsync(DefaultSeed.SeedingSettings());
            }
        }
    }
}
