using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VuexyBase.Domain.Entities.Chats;
using VuexyBase.Domain.Entities.Countries;
using VuexyBase.Domain.Entities.Favorites;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Entities.More;
using VuexyBase.Domain.Entities.Notifications;
using VuexyBase.Domain.Entities.Orders;
using VuexyBase.Domain.Entities.Payments;
using VuexyBase.Domain.Entities.Rates;
using VuexyBase.Domain.Enums.Orders;

namespace VuexyBase.Application.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Chats
        public DbSet<ConnectedUser> ConnectedUsers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Room> Rooms { get; set; }

        // Favorites
        public DbSet<UserFavorite> UserFavorites { get; set; }

        // General
        public DbSet<DeviceToken> DeviceTokens { get; set; }
        public DbSet<AppInfo> AppInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<LogException> LogExceptions { get; set; }
        public DbSet<Setting> Settings { get; set; }

        // More
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }
        //countries 
        public DbSet<Country> Countries { get; set; }

        // Orders
        public DbSet<CancellationReason> CancellationReasons { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ReturnImage> ReturnImages { get; set; }


        // Notifications
        public DbSet<DashboardNotification> DashboardNotifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        // Payments
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }

        // Rates
        public DbSet<UserRate> UserRates { get; set; }

        // IntroScreens
        public DbSet<IntroScreen> IntroScreens { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Global Filters
            builder.Entity<ApplicationDbUser>().HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<ApplicationDbUser>().HasQueryFilter(c => !c.IsBlocked);

            builder.Entity<Room>().HasQueryFilter(c => !c.IsDeleted);

            builder.Entity<Country>().HasQueryFilter(c => !c.isDeleted);

            //Seeds

            //Fluent API
        }
    }
}
