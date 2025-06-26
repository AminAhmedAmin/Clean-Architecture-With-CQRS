using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.Common.Extensions;
using VuexyBase.Application.Application.Common.Helpers;
using VuexyBase.Application.Application.Contracts.Application.API;
using VuexyBase.Application.Application.DTOs.More;
using VuexyBase.Application.Application.DTOs.More.AppInfo;
using VuexyBase.Application.Application.DTOs.Notifications.NotifyList;
using VuexyBase.Application.Common.Results;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Constants;
using VuexyBase.Domain.Entities.More;
using VuexyBase.Domain.Entities.Notifications;

namespace VuexyBase.Application.Application.Services.API.More
{
    internal class MoreService: IMoreService
    {
        private readonly ApplicationDbContext _db;

        public MoreService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext db) 
        {
            _db = db;
        }



        public async Task<Result<List<IntroScreenDto>>> GetIntroScreens(string lang)
        {
            try
            {
                var result = await _db.IntroScreens.Where(x => x.IsActive)
                    .Select(x => new IntroScreenDto
                    {
                        Id = x.Id,
                        Title =lang =="ar" ?x.NameAr:x.NameEn,
                        Description = lang == "ar" ? x.DescriptionAr : x.DescriptionEn,
                        Image = AppRoutes.DashboardUrl + x.BackgroundImage
                    }).ToListAsync();

                return Result<List<IntroScreenDto>>.Success(result, "Success");
            }
            catch
            {
                return Result<List<IntroScreenDto>>.Fail("Error");

            }
        }




        public async Task<Result<List<NotifyListDto>>> ListOfNotifyUser(string userId, string lang, int pageNumber = 1, int pageSize = 10)
        {

            try
            {
                // Set culture dynamically based on the user's language
                var cultureInfo = lang == "ar"
                    ? new System.Globalization.CultureInfo("ar") // Arabic culture
                    : System.Globalization.CultureInfo.InvariantCulture; // Default (English or others)


                var Notifications = await _db.UserNotifications
                   .Where(x => x.UserId == userId)
                   .Select(n => new NotifyListDto
                   {
                       Id = n.Id,
                       Message = lang=="ar"?  n.MessageAr:n.MessageEn,
                       Title = n.Type.GetLocalizedName(lang),
                       date = n.CreationDate.ToString(),
                       Type =(int) n.Type,
                       ItemId = n.ItemId

                   })
                  .Paginate(pageNumber, pageSize); // Apply pagination here




                List<UserNotification> updateNotfy = await _db.UserNotifications.Where(x => x.IsSeen == false && x.UserId == userId).ToListAsync();
                updateNotfy.ForEach(a => a.IsSeen = true);
                await _db.SaveChangesAsync();


                return Result<List<NotifyListDto>>.Success(Notifications.Result, "");

            }

            catch (Exception ex)
            {
                return Result<List<NotifyListDto>>.Fail("Error");
            }



        }

        public async Task<Result<int>> NotifyCount(string userId)
        {
            var userNotifications = await _db.UserNotifications.CountAsync(x => !x.IsSeen == false && x.UserId == userId);



            return Result<int>.Success(userNotifications, "Success");
        }

        public async Task<Result<bool>> DeleteNotify(int id)
        {
            var userNotifications = _db.UserNotifications.Where(n => n.Id == id);

            _db.UserNotifications.RemoveRange(userNotifications);
            await _db.SaveChangesAsync();

            return Result<bool>.Success(true, "DeletedSuccsefully");
        }

        public async Task<Result<bool>> DeleteAllNotify(string ProviderId)
        {
            var userNotifications = _db.UserNotifications.Where(n => n.UserId == ProviderId);

            _db.UserNotifications.RemoveRange(userNotifications);
            await _db.SaveChangesAsync();

            return Result<bool>.Success(true, "DeletedSuccsefully");
        }




        public async Task<Result<AboutUsDto>> AboutUs(string lang = "ar")
        {
            AboutUsDto aboutUsDto = new AboutUsDto()
            {
                aboutUs = await _db.AppInfos
                                   .Select(a => lang == "ar" ? a.AboutUsAr : a.AboutUsAr)
                                   .FirstOrDefaultAsync()
            };



            return Result<AboutUsDto>.Success(aboutUsDto, "");
        }

        public async Task<Result<List<CommonQuestionsDto>>> CommonQuestions(string lang = "ar")
        {
            var question = await _db.FAQs
                .Where(x => x.IsActive)
                                    .Select(q => new CommonQuestionsDto()
                                    {
                                        Question = lang == "ar" ? q.QuestionAr : q.QuestionEn,
                                        Answer = lang == "ar" ? q.AnswerAr : q.AnswerEn
                                    }).ToListAsync();

            return Result<List<CommonQuestionsDto>>.Success(question, "");
        }


        public async Task<Result<TermsAndConditionsDto>> TermsAndConditions(string lang = "ar")
        {
            var termsAndCondition = await _db.AppInfos.Select(t => new TermsAndConditionsDto()
            {
                TermAndCondition = lang == "ar" ? t.TermsAndConditionsAr : t.TermsAndConditionsEn
            }).FirstOrDefaultAsync();

            return Result<TermsAndConditionsDto>.Success(termsAndCondition, "");
        }




        public async Task<Result<bool>> ContactWithUs(ContactWithUsDto contactWithUsDto)
        {
            Contact contactWithUs = new Contact()
            {
                FullName = contactWithUsDto.FullName,
                Email = contactWithUsDto.Email,
                Subject = contactWithUsDto.Subject,
                PhoneNumber = contactWithUsDto.PhoneNumber,
              Message = contactWithUsDto.Message,
                CreationDate = DateTime.Now

            };

            await _db.AddAsync(contactWithUs);

            return Result<bool>.Success(await _db.SaveChangesAsync() > 0 ? true : false, "Success");

        }

        public async Task<Result<PolicyPrivacyDto>> PolicyPrivacy(string lang = "ar")
        {
            var PolicyPrivacy = await _db.AppInfos.Select(t => new PolicyPrivacyDto()
            {
                PolicyPrivacy = lang == "ar" ? t.PrivacyPolicyAr : t.PrivacyPolicyEn
            }).FirstOrDefaultAsync();

            return Result<PolicyPrivacyDto>.Success(PolicyPrivacy, "Success");
        }




        public async Task<Result<ContactInfoDto>> ContactInfo(string lang)
        {

            var ContactInfo = await _db.Settings.Select(t => new ContactInfoDto()
            {
                Email = t.Email,
                PhoneNumber = t.Phone,
                Address = t.Address,



            }).FirstOrDefaultAsync();

         

            return Result<ContactInfoDto>.Success(ContactInfo, "");

        }


    }
}
