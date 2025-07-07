using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VuexyBase.Application.Persistence;
using VuexyBase.Application.Persistence.Seeds;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Entities.UserRoles;

namespace VuexyBase.Infrastructure.Infrastructure.Configurations
{
    public class SeedingConfiguration : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        public SeedingConfiguration(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                try
                {
                    var seeder = new DataSeeder(
                        serviceProvider.GetRequiredService<ApplicationDbContext>(),
                        serviceProvider.GetRequiredService<UserManager<ApplicationDbUser>>(),
                        serviceProvider.GetRequiredService<RoleManager<Role>>()
                    );

                    await seeder.SeedAsync();
                }
                catch
                {
                    throw new Exception("An error occurred while seeding the database.");
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
