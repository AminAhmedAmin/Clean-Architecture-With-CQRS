using VuexyBase.Infrastructure.Configurations;
using VuexyBase.Website.Middlewares;

namespace VuexyBase.Website
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

            builder.Services.AddDefaultIdentityServices();

            #endregion

            #region Services
            builder.Services.AddSingletonServices();
            builder.Services.AddScopedServices();
            builder.Services.AddTransientServices();
            builder.Services.AddServicesScanner();
            #endregion

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

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseUserContext();

            app.UseRateLimiter();

            // ^^API^^
            //app.UseSwagger();
            //app.UseSwaggerUI();

            app.MapControllers();

            // ^^MVC^^
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
