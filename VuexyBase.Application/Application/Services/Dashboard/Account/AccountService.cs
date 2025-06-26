using Google.Api.Gax.ResourceNames;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Common.Helpers;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Account;
using VuexyBase.Application.Application.ViewModels.Profile;
using VuexyBase.Application.Common.Helpers;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Constants;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Helper;

namespace VuexyBase.Application.Application.Services.Dashboard.Account
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _db;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly UserManager<ApplicationDbUser> _userManager;

        public AccountService(ApplicationDbContext db, IHostingEnvironment HostingEnvironment, UserManager<ApplicationDbUser> userManager)
        {
            _db = db;
            _hostingEnvironment = HostingEnvironment;
            _userManager = userManager;
        }

        public async Task<UpdateProfileViewModel> AccountData()
        {
            var userId = BaseHelper.UserId;

            var setting = await _db.Settings
                                   .Select(s => new
                                   {
                                       organizationName = s.SenderName,
                                       address = s.Address,
                                   }).FirstOrDefaultAsync();

            var account = await _db.Users
                                   .Where(u => u.Id == userId)
                                   .Select(u => new UpdateProfileViewModel()
                                   {
                                       oldImage = AppRoutes.DashboardUrl + u.ProfileImage,
                                       name = u.User_Name,
                                       phone = u.PhoneNumber,
                                       email = u.Email,
                                       organizationName = setting.organizationName,
                                       address = setting.address
                                   }).FirstOrDefaultAsync();

            return account;
        }

        public async Task<bool> UpdateProfile(UpdateProfileViewModel model)
        {
            var userId = BaseHelper.UserId;

            var user = await _db.Users
                                .FindAsync(BaseHelper.UserId);

            var setting = await _db.Settings
                                   .FirstOrDefaultAsync();

            if (user == null)
                return false;

            user.User_Name = model.name;
            user.PhoneNumber = model.phone;
            user.Email = model.email;
            setting.Address = model.address;
            setting.SenderName = model.organizationName;

            if (model.newImage != null)
            {
                var imagePath =  UploadHelper.Upload(model.newImage, (int)FileName.Country, _hostingEnvironment);
                user.ProfileImage = imagePath;
            }
            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return true;
        }


        public async Task<bool> ChangePassword(ChangePasswordViewModel model)
        {
            var user = await _db.Users
                                .FindAsync(BaseHelper.UserId);

            var result = await UpdatePassword(user, model.currentPassword, model.newPassword);

            if (result.IsSuccess)
                return true;

            return false;
        }

        public async Task<(bool IsSuccess, string messageKey)> UpdatePassword(ApplicationDbUser user, string currentPassword, string newPassword)
        {
            var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

            if (!result.Succeeded)
                return (false, "ErrorChangingPassword");

            _db.Users.Update(user);
            await _db.SaveChangesAsync();

            return (true, "PasswordResetedSuccessfully");
        }
    }
}
