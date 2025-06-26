using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.User;
using VuexyBase.Application.Persistence;
using VuexyBase.Dashboard.ViewModels.User;
using VuexyBase.Domain.Constants;

namespace VuexyBase.Application.Application.Services.Dashboard.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext db;

        public UserService(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async Task<UserIndexViewModel> UserIndex()
        {
            var users = await db.Users
                                .ToListAsync();

            var statics = new UserStaticsViewModel()
            {
                totalUserCount = users.Count(),
                totalActiveUsers = users.Where(a => a.IsActive).Count(),
                totalUnActiveUsers = users.Where(a => !a.IsActive).Count(),
                totalBlockedUsers = users.Where(a => !a.IsBlocked).Count(),
            };

            var allUsers = users.Select(u => new UserDataViewModel()
            {
                id = u.Id,
                name = u.User_Name,
                image = AppRoutes.APIUrl + u.ProfileImage,
                email = u.Email,

                
            }).ToList();

            var result = new UserIndexViewModel()
            {
                statics = statics,
                users = allUsers
            };

            return result;

        }
    }
}
