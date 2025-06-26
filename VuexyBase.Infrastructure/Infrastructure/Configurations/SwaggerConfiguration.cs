using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace VuexyBase.Infrastructure.Infrastructure.Configurations
{
    public class SwaggerConfiguration : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            ConfigureSwaggerDoc(options);
            ConfigureSecurity(options);
            //ConfigureXmlComments(options); <-- Please put you xml files paths here
            options.OperationFilter<SwaggerCustomHeaderAttribute>();
        }
        private void ConfigureSwaggerDoc(SwaggerGenOptions options)
        {
            options.SwaggerDoc("Test", new OpenApiInfo { Title = "Test", Version = "v1" });
            options.SwaggerDoc("Auth", new OpenApiInfo { Title = "Auth", Version = "v1" });
            options.SwaggerDoc("More", new OpenApiInfo { Title = "More", Version = "v1" });


        }

        private void ConfigureSecurity(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT authorization header using the bearer scheme."
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
            });
        }

        private void ConfigureXmlComments(SwaggerGenOptions options)
        {
            string[] xmlFiles =
            {
                Path.Combine(Environment.CurrentDirectory, "VuexyBase.Service.xml"),
                Path.Combine(Environment.CurrentDirectory, "VuexyBase.xml")
            };

            foreach (var xmlFile in xmlFiles)
            {
                options.IncludeXmlComments(xmlFile);
            }
        }
    }

    public class SwaggerUIConfiguration : IConfigureOptions<SwaggerUIOptions>
    {
        public void Configure(SwaggerUIOptions options)
        {
            options.RoutePrefix = "Swagger";
            options.SwaggerEndpoint("/Swagger/Test/Swagger.json", "Test");
            options.SwaggerEndpoint("/Swagger/Auth/Swagger.json", "Auth");
            options.SwaggerEndpoint("/Swagger/More/Swagger.json", "More");
        }
    }

    public class SwaggerCustomHeaderAttribute : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter
            {
                Name = "Accept-Language",
                In = ParameterLocation.Header,
                Required = false,
                Schema = new OpenApiSchema
                {
                    Type = "String"
                },
                Example = new OpenApiString("ar"),
            });
        }
    }
}

