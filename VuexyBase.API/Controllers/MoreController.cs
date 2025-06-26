using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using VuexyBase.API.Controllers.Shared;
using VuexyBase.Application.Application.Contracts.Application.API.Auth;
using VuexyBase.Application.Application.Contracts.Application.API.Home;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Auth;
using VuexyBase.Application.Application.DTOs.Auth;
using VuexyBase.Application.Common.Results;
using VuexyBase.Domain.Constants;

namespace VuexyBase.API.Controllers
{


  
    [Route("API/More")]
    [ApiExplorerSettings(GroupName = "More")]
    public class MoreController : BaseAPIController
    {



        private readonly IAccountService _accountService;

   
        public MoreController(IAccountService accountService)
        {
            _accountService = accountService;
         
        }





        /// <summary>
        /// GetIntroScreens.
        ///     الانترو او صفحات البدايه .
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب   لعرض صفحات البدايه.
        ///
        /// **Figma Link:**
        /// * [Figma Prototype Mobile](http://figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=33-1029&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.GetIntroScreens)]
        //public async Task<IActionResult> GetIntroScreens()
        //{
        //    var result = await _moreService.GetIntroScreens(lang);
        //    return StatusCode(result.StatusCode, result);
        //}



        /// <summary>
        /// Wallet.
        ///     المحفظة.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب   لعرض المحفظة.
        ///
        /// **Figma Link:**
        /// * [Figma Prototype Mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-1868&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-7853&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[HttpGet(ApiRoutes.More.Wallet)]
        //public async Task<IActionResult> Wallet()
        //{
        //    var result = await _moreService.Wallet(userId, lang);
        //    return StatusCode(result.StatusCode, result);
        //}



        /// <summary>
        /// ChargeWallet.
        ///  شحن المحفظه لغرض التيتست .
        /// </summary>
        /// <remarks>
        /// # هذه هي البيانات المطلوبة لتحديث معلومات المستخدم.
        /// * ادخل الكميه بالريال 
        /// 
        /// **Figma Link:**
        /// * [Figma Prototype Mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-1868&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-7853&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        "Amount": "10000",
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>



        //[HttpPost(ApiRoutes.More.ChargeWallet)]
        //public async Task<IActionResult> ChargeWallet(ChargeWalletDto chargeWalletDto)
        //{
        //    var result = await _moreService.ChargeWallet(userId, chargeWalletDto);
        //    return StatusCode(result.StatusCode, result);
        //}



        /// <summary>
        /// ListFavourite.
        ///     المفضلة.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب   لعرض المفضلة.
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=69-6944&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-8605&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[HttpGet(ApiRoutes.More.ListFavourite)]
        //public async Task<IActionResult> ListFavourite()
        //{
        //    var result = await _moreService.ListFavourite(userId, lang);
        //    return StatusCode(result.StatusCode, result);
        //}





        /// <summary>
        /// RegisterProvider.
        ///    تسجيل مقدم الخدمه
        /// </summary>
        /// <remarks>
        /// # هذه هي البيانات المطلوبة لتسجيل مقدم الخدمه جديد.
        /// * يجب أن يكون رقم الهاتف متوافقًا مع الصيغة السعودية  phone must match:@"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$".
        /// * يجب رفع صورة بصيغة صحيحة.
        /// *رقم الحساب 16 رقم
        /// * يجب تحديد القسم التي ينتمي إليها المستخدم. ==> shared.
        /// * يجب تحديد منصات تواصل التي ينتمي إليها المستخدم. ==> shared.
        ///
        /// Sample request:
        /// 
        ///      {
        ///          "Phone": "512345678",
        ///          "Name": "amin",
        ///          "CategoryId": "1",
        ///          "ProfileImage": "file",
        ///          "CommercialRegisterImage": 1,
        ///          "BankName": 1,
        ///          "AccountNumber": 1234567812345678,
        ///          "Socail": {
        ///            "id": "1",
        ///            "link": "Android"
        ///          }
        ///      }
        /// 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[AllowAnonymous]
        //[HttpPatch(ApiRoutes.More.RegisterProvider)]
        //public async Task<IActionResult> Register([FromForm] RegisterProviderDto registerUser)
        //{
        //    var result = await _authService.RegisterProvider(registerUser);
        //    return StatusCode(result.StatusCode, result);
        //}

        /// <summary>
        /// GetUserInfo.
        ///     الملف الشخصي.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب   لعرض الملف الشخصي للمستخدم.
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=143-858&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-5497&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>


        //[ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.More.GetUserInfo)]
        //public async Task<IActionResult> GetUserInfo()
        //{

        //    var result = await _accountService.GetUserData(userId, lang);
        //    return StatusCode(result.StatusCode, result);

        //}

        /// <summary>
        /// Update user information.
        /// تحديث معلومات المستخدم.
        /// </summary>
        /// <remarks>
        /// # هذه هي البيانات المطلوبة لتحديث معلومات المستخدم.
        /// * يمكن تحديث اسم المستخدم.
        /// * يمكن تحديث صورة المستخدم.
        /// * يجب تحديد المدينة التي ينتمي إليها المستخدم. ====>Shared
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=143-858&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-5995&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        "UserName": "Updated Name",
        ///        "Image": "file",
        ///        "CityId": 2
        ///      }
        ///      ```
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>




        //[ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpPatch(ApiRoutes.More.UpdateUserInfo)]
        //public async Task<IActionResult> UpdateUserInfo(UpdateUserInfo UpdateUserInfo)
        //{
        //    var result = await _accountService.UpdateUserInfo(UpdateUserInfo, userId, lang);
        //    return StatusCode(result.StatusCode, result);


        //}




        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.ChangeLanguage)]
        //public async Task<IActionResult> ChangeLanguage()
        //{
        //    var result = await _moreService.ChangeLanguage(lang, userId);
        //    return StatusCode(result.StatusCode, result);
        //}







        /// <summary>
        /// تغيير رقم الجوال .
        ///    CkeckPhone
        /// </summary>
        /// <remarks>
        /// #    دي بستخدمها عشان اغير رقم الهاتف .
        /// *   اول حاجه هتبعت كود عن طريق الresendcode 
        /// *   تاني حاجه هتاكد رقم الهاتف عن طريق comfirmcode.
        /// * بعد كدا هترن السرفيس دي عشان تشيك علي الهاتف الجديد دا مستخدم ولا لا لو مش مستخدم تمام هيبعت كود تلقائي 
        /// * بعد كدا هترن سيرفيس  ConfirmCodeByPhone  عشان تاكد الهاتف الجديد
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-2796&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-7279&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        phone:561212121
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.More.CkeckPhone)]
        //public async Task<IActionResult> CkeckPhone(string phone)
        //{
        //    var result = await _accountService.CkeckPhone(phone, lang);
        //    return StatusCode(result.StatusCode, result);


        //}



        /// <summary>
        /// تغيير رقم الجوال .
        ///    CkeckPhone
        /// </summary>
        /// <remarks>
        /// #    دي بستخدمها عشان اغير رقم الهاتف .
        /// *   اول حاجه هتبعت كود عن طريق الresendcode 
        /// *   تاني حاجه هتاكد رقم الهاتف عن طريق comfirmcode.
        /// * بعد كدا هترن السرفيس CkeckPhone عشان تشيك علي الهاتف الجديد دا مستخدم ولا لا لو مش مستخدم تمام هيبعت كود تلقائي 
        /// * بعد كدا هترن السيرفيس دي    عشان تاكد الهاتف الجديد
        ///
        /// **Figma Link:**
        /// * [Figma Link mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-2836&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-6842&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///        phone:561212121,
        ///        code:1234
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        //[ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpPatch(ApiRoutes.More.ConfirmCodeByPhone)]
        //public async Task<IActionResult> ConfirmCodeByPhone(ConfirmCodeByPhone confirmCodeByPhone)
        //{
        //    var result = await _accountService.ConfirmCodeByPhone(confirmCodeByPhone, userId, lang);
        //    return StatusCode(result.StatusCode, result);


        //}


        /// <summary>
        /// الاشعارات    .
        ///    ListOfNotifyClient
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان اعرض الاشعارات  .
        /// *  pageNumber دي عشان البجانيشن رقم الصفحه
        /// *  pageSize دي عدد العناصر في الصفحة.
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=150-2558&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=482-17670&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>


        //[ProducesResponseType(typeof(Result<List<NotifyListDto>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpGet(ApiRoutes.More.ListOfNotifyClient)]
        //public async Task<IActionResult> ListOfNotifyClient(int pageNumber = 1, int pageSize = 5)
        //{
        //    var result = await _moreService.ListOfNotifyUser(userId, lang, pageNumber, pageSize);
        //    return StatusCode(result.StatusCode, result);
        //}

        //[ProducesResponseType(typeof(Result<List<NotifyListDto>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpDelete(ApiRoutes.More.DeleteNotify)]
        //public async Task<IActionResult> DeleteNotify(int Id)
        //{
        //    var result = await _moreService.DeleteNotify(Id);
        //    return StatusCode(result.StatusCode, result);
        //}

        //[ProducesResponseType(typeof(Result<List<bool>>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpDelete(ApiRoutes.More.DeleteAllNotify)]
        //public async Task<IActionResult> DeleteAllNotify()
        //{
        //    var result = await _moreService.DeleteAllNotify(userId);
        //    return StatusCode(result.StatusCode, result);
        //}

        //[HttpGet(ApiRoutes.More.NotifyCount)]
        //public async Task<IActionResult> NotifyCount()
        //{
        //    var result = await _moreService.NotifyCount(lang);
        //    return StatusCode(result.StatusCode, result);
        //}


        //[ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        //[HttpDelete(ApiRoutes.More.DeleteAllNotifyClient)]
        //public async Task<IActionResult> DeleteAllNotifyUser()
        //{
        //    var result = await _moreService.DeleteAllNotify(UserId);
        //    return StatusCode(result.StatusCode, result);
        //}



        /// <summary>
        /// من نحن    .
        ///    AboutUs
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان اعرض من نحن  .
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-3051&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=346-5080&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.AboutUs)]
        //public async Task<IActionResult> AboutUs()
        //{
        //    var result = await _moreService.AboutUs(lang);
        //    return StatusCode(result.StatusCode, result);
        //}


        /// <summary>
        ///  الاسئلة الشائعة    .
        ///    CommonQuestions
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان اعرض الاسئلة الشائعة  .
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=69-7052&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=346-6645&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        ///  
        /// Sample request:
        /// 
        ///      {
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.CommonQuestions)]
        //public async Task<IActionResult> CommonQuestions()
        //{
        //    var result = await _moreService.CommonQuestions(lang);
        //    return StatusCode(result.StatusCode, result);
        //}




        /// <summary>
        ///   تواصل معنا    .
        ///    ContactWithUs
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان   تواصل معنا  .
        ///  * الاسم مطلوب
        ///  * الايميل مطلوب
        ///  * العنوان مطلوب
        ///  * الرسالة مطلوب
        /// 
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-4636&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=767-8098&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///       UserName: amin,
        ///       email: test ,
        ///       title :test,
        ///       message:test,   
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>   

        //[AllowAnonymous]
        //[HttpPost(ApiRoutes.More.ContactWithus)]
        //public async Task<IActionResult> ContactWithUs([FromForm] ContactWithUsDto contactWithUs)
        //{
        //    var result = await _moreService.ContactWithUs(contactWithUs);
        //    return StatusCode(result.StatusCode, result);
        //}





        /// <summary>
        ///   الشروط والاحكام    .
        ///    TermsAndConditions
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان اعرض  الشروط والاحكام  .
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-3773&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=346-5717&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.TermsAndConditions)]
        //public async Task<IActionResult> TermsAndConditions()
        //{
        //    var result = await _moreService.TermsAndConditions(lang);
        //    return StatusCode(result.StatusCode, result);
        //}


        /// <summary>
        ///    سيساسة الحصوصية    .
        ///    PolicyPrivacy
        /// </summary>
        /// <remarks>
        /// #    بستخدمها عشان اعرض   سيساسة الحصوصية   .
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=132-4163&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=346-6181&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///       
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        //[AllowAnonymous]
        //[HttpGet(ApiRoutes.More.PolicyPrivacy)]
        //public async Task<IActionResult> PolicyPrivacy()
        //{
        //    var result = await _moreService.PolicyPrivacy(lang);
        //    return StatusCode(result.StatusCode, result);
        //}





 

    }
}
