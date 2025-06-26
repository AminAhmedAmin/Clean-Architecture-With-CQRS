using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.DTOs.More;
using VuexyBase.Application.Application.DTOs.More.AppInfo;
using VuexyBase.Application.Application.DTOs.Notifications.NotifyList;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Application.Application.Contracts.Application.API
{
    public interface IMoreService
    {
        Task<Result<List<CommonQuestionsDto>>> CommonQuestions(string lang = "ar");
        Task<Result<ContactInfoDto>> ContactInfo(string lang);
        Task<Result<bool>> ContactWithUs(ContactWithUsDto contactWithUsDto);
        Task<Result<bool>> DeleteAllNotify(string ProviderId);
        Task<Result<bool>> DeleteNotify(int id);
        Task<Result<List<IntroScreenDto>>> GetIntroScreens(string lang);
        Task<Result<List<NotifyListDto>>> ListOfNotifyUser(string userId, string lang, int pageNumber = 1, int pageSize = 10);
        Task<Result<int>> NotifyCount(string userId);
        Task<Result<PolicyPrivacyDto>> PolicyPrivacy(string lang = "ar");
        Task<Result<TermsAndConditionsDto>> TermsAndConditions(string lang = "ar");
    }
}
