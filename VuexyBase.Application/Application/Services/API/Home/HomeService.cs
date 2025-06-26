using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.API.Home;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Application.Application.Services.API.Home
{
    public class HomeService : IHomeService
    {
        private readonly ApplicationDbContext _db;

        public HomeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task SaveIncludeAsync(ApplicationDbUser entity, params string[] properties)
        {
            var local = _db.Users
                           .Local
                           .FirstOrDefault(x => x.Id == entity.Id);

            EntityEntry<ApplicationDbUser> entry;

            if (local is null)
            {
                //entry = _db.Attach(entity);
                entry = _db.Entry(entity);

            }
            else
            {
                entry = _db.ChangeTracker
                           .Entries<ApplicationDbUser>()
                           .FirstOrDefault(x => x.Entity.Id == entity.Id);
            }

            foreach (var property in entry.Properties)
            {
                if (properties.Contains(property.Metadata.Name))
                {
                    property.CurrentValue = entity.GetType().GetProperty(property.Metadata.Name).GetValue(entity);
                    property.IsModified = true;
                }
            }
            await _db.SaveChangesAsync();
        }
    }
}
