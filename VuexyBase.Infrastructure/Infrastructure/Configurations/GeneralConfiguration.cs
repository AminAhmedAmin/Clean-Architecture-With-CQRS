using System.Reflection;
using System.Text;
using System.Threading.RateLimiting;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using VuexyBase.Application.Application.Contracts.Application.Countries;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Category;
using VuexyBase.Application.Application.Contracts.Infrastructure.IO;
using VuexyBase.Application.Application.Contracts.Infrastructure.Notifications.Firebase;
using VuexyBase.Application.Application.Contracts.Infrastructure.SMS.FourJawaly;
using VuexyBase.Application.Application.DependencyInjection;
using VuexyBase.Application.Application.Services.Countries;
using VuexyBase.Application.Application.Services.Dashboard.Auth;
using VuexyBase.Application.Application.Services.Dashboard.Category;
using VuexyBase.Application.Common.Extensions;
using VuexyBase.Application.Common.Helpers;
using VuexyBase.Application.Persistence;
using VuexyBase.Application.Services.Localization;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Infrastructure.Infrastructure.Configurations;
using VuexyBase.Infrastructure.Infrastructure.DependencyInjection;
using VuexyBase.Infrastructure.Infrastructure.Services.IO;
using VuexyBase.Infrastructure.Infrastructure.Services.SMS.FourJawaly;
using VuexyBase.Infrastructure.Services.Notifications.Firebase;

namespace VuexyBase.Infrastructure.Configurations
{
    public static class GeneralConfiguration
    {
        #region Identity & Encryption
        public static void AddDbContextServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.UseLazyLoadingProxies();
            });
        }

        public static void AddDefaultIdentityServices(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationDbUser>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
            }).AddRoles<IdentityRole>()/*.AddDefaultUI()*/.AddEntityFrameworkStores<ApplicationDbContext>();
        }

        public static void AddJWTServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(options => { }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:Site"],
                    ValidIssuer = Configuration["JWT:Site"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SigningKey"]!))
                };
            });
        }


        public static void AddSecretKeys(this IServiceCollection services, IConfiguration Configuration)
        {
            CryptographyExtension.Key = Configuration["Encryption:Key"]!;

            #region FourJawaly
            FourJawalyService.SenderName = Configuration["FourJawaly:sender_name"]!;
            FourJawalyService.AppKey = Configuration["FourJawaly:app_key"]!;
            FourJawalyService.AppSecret = Configuration["FourJawaly:app_secret"]!;
            FourJawalyService.Url = Configuration["FourJawaly:url"]!;
            #endregion
        }
        #endregion

        #region Services

        public static void AddScopedServices(this IServiceCollection services)
        {
            //services.AddScoped<ITestService, TestService>();
        }


        public static void AddTransientServices(this IServiceCollection services)
        {
            #region SMS
            services.AddTransient<IFourJawalyService, FourJawalyService>();
            #endregion

            #region Notifications
            services.AddTransient<IFirebaseService, FirebaseService>();
            #endregion

            #region IO
            services.AddTransient<IFileService, FileService>();
            #endregion

            #region Identities
            services.AddTransient<IAuthService, AuthService>();
            #endregion

            #region
            services.AddTransient<ICountriesService, CountriesService>();
            #endregion

          services.AddTransient<ICategoryService, CategoryService>();

        }

        public static void AddSingletonServices(this IServiceCollection services)
        {
            //services.AddSingleton<ITestService, TestService>();
        }

        #region Scanner
        public static void AddServicesScanner(this IServiceCollection services)
        {
            services.Scan(scan => scan
                .FromAssemblyOf<AssemblyHelper>()
                .AddClasses(classes => classes.Where(type =>
                    (type.IsInterface || type.IsClass) &&
                    (type.Name.EndsWith("Service") || type.Name.EndsWith("Services"))
                ))
                .AsImplementedInterfaces()
                .WithTransientLifetime()
            );
        }
        #endregion

        #endregion

        #region Localization
        public static void AddLocalizationServices(this IServiceCollection services)
        {
            services.AddLocalization();
            services.AddSingleton<IStringLocalizer, LocalizationService>();
        }

        #endregion

        #region Firebase
        public static void AddFireBase(this IServiceCollection services, IConfiguration configuration)
        {
            var firebaseConfig = configuration.GetSection("Firebase").Get<Dictionary<string, string>>();

            if (firebaseConfig == null)
                throw new InvalidOperationException("Firebase configuration is missing from appsettings.json");

            var credentialJson = System.Text.Json.JsonSerializer.Serialize(firebaseConfig);

            //^^Uncomment to use firebase if you put your credentials in appsettings.json^^
            //FirebaseApp.Create(new AppOptions()
            //{
            //    Credential = GoogleCredential.FromJson(credentialJson)
            //});
        }
        #endregion

        #region Fluent Validation
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(typeof(AssemblyHelper).Assembly);

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddFluentValidationAutoValidation();

            services.AddFluentValidationClientsideAdapters();
        }
        #endregion
        #region Autofac Setup


        public static void AddAutofac(this WebApplicationBuilder builder)
        {
            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>((context, containerBuilder) =>
            {
                containerBuilder.RegisterModule(new ApplicationModule());
                containerBuilder.RegisterModule(new InfrastructureModule());
            });
        }


        #endregion


        #region API Configuration
        public static void AddAPIConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, SwaggerConfiguration>();

            services.AddTransient<IConfigureOptions<SwaggerUIOptions>, SwaggerUIConfiguration>();

            services.AddJWTServices(configuration);

            services.AddFireBase(configuration);


        }
        #endregion

        #region MVC Configuration
        public static void AddMVCConfiguration(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddRazorPages();
        }
        #endregion

        #region Rate Limiting
        public static void AddRateLimiting(this IServiceCollection services)
        {
            services.AddRateLimiter(options =>
             {
                 static FixedWindowRateLimiterOptions CreateLimiter(int permitLimit, int windowSeconds, int queueLimit) =>
                     new()
                     {
                         PermitLimit = permitLimit,
                         Window = TimeSpan.FromSeconds(windowSeconds),
                         QueueLimit = queueLimit
                     };

                 // Define policies
                 options.AddPolicy("Restrict", httpContext =>
                     RateLimitPartition.GetFixedWindowLimiter(
                         httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                         _ => CreateLimiter(permitLimit: 1, windowSeconds: 5, queueLimit: 1)));

                 options.AddPolicy("Normal", httpContext =>
                     RateLimitPartition.GetFixedWindowLimiter(
                         httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                         _ => CreateLimiter(permitLimit: 1, windowSeconds: 1, queueLimit: 1)));

                 options.AddPolicy("Open", httpContext =>
                     RateLimitPartition.GetFixedWindowLimiter(
                         httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                         _ => CreateLimiter(permitLimit: 5, windowSeconds: 1, queueLimit: 5)));


                 options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
             });
        }
        #endregion

        #region Seeding
        public static void AddSeedingData(this IServiceCollection services)
        {
            //services.AddHostedService<SeedingConfiguration>();
        }
        #endregion


        //No configurations below!
        #region Mappers

        #endregion

        #region CORS

        #endregion

        #region Session - Cookies
        #endregion
    }
}
