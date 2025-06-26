using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Identities;

namespace VuexyBase.Application.Persistence.Seeds
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationDbUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DataSeeder(ApplicationDbContext context, UserManager<ApplicationDbUser> userManager, RoleManager<IdentityRole> roleManager)
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
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
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
