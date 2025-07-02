using Microsoft.AspNetCore.Identity;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Entities.UserRoles;
using VuexyBase.Domain.Enums.Identities;
using VuexyBase.Domain.Enums.Languages;

namespace VuexyBase.Application.Persistence.Seeds
{
    internal static class DefaultSeed
    {
        // Method to seed AppInfo
        public static AppInfo SeedingAppInfos()
        {
            return new AppInfo
            {
                TermsAndConditionsAr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                TermsAndConditionsEn = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                AboutUsAr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                AboutUsEn = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                PrivacyPolicyAr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                PrivacyPolicyEn = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                CancellationPolicyAr = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero.",
                CancellationPolicyEn = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer nec odio. Praesent libero."
            };
        }

        // Method to seed roles
        public static List<IdentityRole> SeedingRoles()
        {
            var roles = Enum.GetValues(typeof(Roles)).Cast<Roles>().Select(role => new IdentityRole(role.ToString())).ToList();
            return roles;
        }

        // Method to seed settings
        public static Setting SeedingSettings()
        {
            return new Setting
            {
                Phone = "0123456789",
                Email = "text@example.com",
                Lat = 28.343727109809066,
                Lng = 25.90159610048603,
                Address = "Matruh, Egypt",
                SenderName = "VuexyBase"
            };
        }
        
        // Method to seed permissions
        public static List<Permission> Seedingpermissions()
        {
            var permissions = new List<Permission>
    {
        new Permission { Id = 1, Category = "User Management", Action = "Read" },
        new Permission { Id = 2, Category = "User Management", Action = "Write" },
        new Permission { Id = 3, Category = "User Management", Action = "Create" },

        new Permission { Id = 4, Category = "Content Management", Action = "Read" },
        new Permission { Id = 5, Category = "Content Management", Action = "Write" },
        new Permission { Id = 6, Category = "Content Management", Action = "Create" },

         };
            return permissions;
        }

        // Method to seed users
        public static List<ApplicationDbUser> SeedingUsers()
        {
            return new List<ApplicationDbUser>
            {
                new ApplicationDbUser
                {
                    UserName = "test@test.com",
                    User_Name = "test@test.com",
                    Email = "test@test.com",
                    EmailConfirmed = true,
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    ProfileImage = string.Empty,
                    VerificationCode = "123456",
                    IsActive = true,
                    IsNotificationsAllowed = true,
                    IsCodeVerified = true,
                    IsBlocked = false,
                    Wallet = 100.00m,
                    UserType = UserType.Admin,
                    Language = Language.Ar,
                    CreationDate = DateTime.UtcNow
                },
                new ApplicationDbUser
                {
                    UserName = "aait@aait.com",
                    User_Name = "aait@aait.com",
                    Email = "aait@aait.com",
                    EmailConfirmed = true,
                    PhoneNumber = "123456",
                    PhoneNumberConfirmed = true,
                    ProfileImage = string.Empty,
                    VerificationCode = "123456",
                    IsActive = true,
                    IsNotificationsAllowed = true,
                    IsCodeVerified = true,
                    IsBlocked = false,
                    Wallet = 100.00m,
                    UserType = UserType.Admin,
                    Language = Language.Ar,
                    CreationDate = DateTime.UtcNow
                },
                new ApplicationDbUser
                {
                    UserName = "aait@test.com",
                    User_Name = "aait@test.com",
                    Email = "aait@test.com",
                    EmailConfirmed = true,
                    PhoneNumber = "123456",
                    PhoneNumberConfirmed = true,
                    ProfileImage = string.Empty,
                    VerificationCode = "123456",
                    IsActive = true,
                    IsNotificationsAllowed = true,
                    IsCodeVerified = true,
                    IsBlocked = false,
                    Wallet = 100.00m,
                    UserType = UserType.Manager,
                    Language = Language.Ar,
                    CreationDate = DateTime.UtcNow
                }
            };
        }
    }
}
