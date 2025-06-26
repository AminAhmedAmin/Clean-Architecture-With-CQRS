using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;
using VuexyBase.Application.Persistence;
using VuexyBase.Dashboard.Middlewares;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Infrastructure.Configurations;

namespace VuexyBase.Dashboard
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ^^API^^
            //builder.Services.AddAPIConfiguration(builder.Configuration);

            // ^^MVC^^
            builder.Services.AddMVCConfiguration();

            #region Identity & Encryption

            builder.Services.AddDbContextServices(builder.Configuration);
            builder.Services.AddSecretKeys(builder.Configuration);

            // Configure Identity
            builder.Services.AddIdentity<ApplicationDbUser, IdentityRole>(options =>
            {
                // إعدادات الباسورد
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                // إعدادات المستخدم
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Auth/Login";  // مسار تسجيل الدخول
                options.AccessDeniedPath = "/Account/AccessDenied"; // مسار رفض الوصول

                options.Cookie.HttpOnly = true;   // منع جافاسكريبت من قراءة الكوكي
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; // ضمان إرسالها فقط مع HTTPS
                options.Cookie.SameSite = SameSiteMode.Strict; // منع إرسالها إلى مواقع أخرى (حماية ضد CSRF)

                options.ExpireTimeSpan = TimeSpan.FromDays(60);  // انتهاء الجلسة بعد 60 يوم
                options.SlidingExpiration = true; // تجديد الجلسة تلقائيًا لو المستخدم شغال
            });

            #endregion

            #region Services
            builder.Services.AddSingletonServices();
            builder.Services.AddScopedServices();
            builder.Services.AddTransientServices();
            builder.Services.AddServicesScanner();
            #endregion

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddLocalizationServices();

            builder.Services.AddSeedingData();

            builder.Services.AddFluentValidation();

            builder.Services.AddRateLimiting();

            builder.Services.AddSignalR();

            var app = builder.Build();

            // ^^MVC^^
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            var supportedCultures = new[] { "en", "ar" };
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList(),
                SupportedUICultures = supportedCultures.Select(c => new CultureInfo(c)).ToList()
            };

            app.UseRequestLocalization(localizationOptions); 


            app.UseRouting();

            var locOptions = app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseUserContext();

            app.UseRateLimiter();

            // ^^API^^
            //app.UseSwagger();
            //app.UseSwaggerUI();
            app.UseMiddleware<GlobalErrorHandlerMiddleware>();
            app.UseMiddleware<TransactionMiddleware>();

            app.MapControllers();

            // ^^MVC^^
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
