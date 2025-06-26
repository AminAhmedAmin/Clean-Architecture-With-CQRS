using Microsoft.AspNetCore.Authorization;
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


  
    [Route("API/Auth")]
    [ApiExplorerSettings(GroupName = "Auth")]
    public class AuthController: BaseAPIController
    {



        private readonly IAccountService _accountService;

   
        public AuthController(IAccountService accountService)
        {
            _accountService = accountService;
         
        }





        /// <summary>
        /// تسجيل مستخدم جديد.
        /// </summary>
        /// <remarks>
        /// # هذه هي البيانات المطلوبة لتسجيل مستخدم جديد.
        /// * يجب أن يكون البريد الإلكتروني صحيحًا وفقًا للتنسيق  Email must match: @"^[a-zA-Z0-9.!#$%'*+/=?^_`{|}~-]{2,}@[a-zA-Z0-9]+(?:[a-zA-Z0-9-]*[a-zA-Z0-9]\.)+[a-zA-Z]{2,}$".
        /// * يجب أن يكون رقم الهاتف متوافقًا مع الصيغة السعودية  phone must match:@"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$".
        /// * يجب رفع صورة بصيغة صحيحة.
        /// * يجب تحديد المدينة التي ينتمي إليها المستخدم. ==> shared.
        /// 
        /// **Figma Link:**
        /// * [Figma Link mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=31-13&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=298-9490&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        ///
        /// Sample request:
        /// 
        ///      {
        ///          "UserName": "amin",
        ///          "Email": "test@example.com",
        ///          "Phone": "512345678",
        ///          "Image": "file",
        ///          "CityId": 1,
        ///          "Device": {
        ///            "DeviceId": "12345",
        ///            "DeviceType": "Android"
        ///          }
        ///      }
        /// 
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromForm] RegisterDto input)
        {
            var result = await _accountService.Register(input);
            return StatusCode(result.StatusCode, result);
        }





        /// <summary>
        /// Confirm a verification code.
        /// تأكيد كود التحقق.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب لتأكيد رمز التحقق المرسل إلى المستخدم.
        /// * يجب أن يكون رقم الهاتف متوافقًا مع الصيغة السعودية  phone must match:@"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$".
        /// * يجب إدخال كود تحقق صحيح.
        /// 
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=31-645&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=298-9771&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///          "PhoneNumber": "512345678",
        ///          "Code": 123456,
        ///          "Device": {
        ///            "DeviceId": "12345",
        ///            "DeviceType": "Android"
        ///          }
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPatch("ConfirmCode")]
        public async Task<IActionResult> ConfirmCode([FromBody] ConfirmCodeDto input)
        {
            var result = await _accountService.ConfirmCode(input, lang);
            return StatusCode(result.StatusCode, result);
        }







        /// <summary>
        /// resend a verification code.
        /// اعادة ارسال كود التحقق.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب لاعادة ارسال رمز التحقق المرسل إلى المستخدم.
        /// * يجب أن يكون رقم الهاتف متوافقًا مع الصيغة السعودية  phone must match:@"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$".
        /// 
        /// **Figma Link:**
        /// * [Figma link mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=31-645&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=298-9771&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///          "PhoneNumber": "512345678",
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>

        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost("ResendCode")]
        public async Task<IActionResult> ResendCode([FromBody] ResendCodeDto input)
        {
            var result = await _accountService.ResendCode(input);
            return StatusCode(result.StatusCode, result);
        }








        /// <summary>
        /// Login.
        ///   تسجيل الدخول.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب لتسجيل دخول المستخدم.
        /// * يجب أن يكون رقم الهاتف متوافقًا مع الصيغة السعودية  phone must match:@"^(5)(5|0|3|6|4|9|1|8|7)([0-9]{7})$".
        ///
        /// 
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=27-14&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=298-72&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        /// 
        /// Sample request:
        /// 
        ///      {
        ///          "PhoneNumber": "512345678",
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        [AllowAnonymous]
        [ProducesResponseType(typeof(Result<UserInfoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto input)
        {
            var result = await _accountService.Login(input);
            return StatusCode(result.StatusCode, result);
        }




        /// <summary>
        /// Logout.
        ///   تسجيل الخروج.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب لتسجيل خروج المستخدم.
        /// * DeviceId   رقم او الاي دي الخاص بالجهاز المستخدم عند التسجيل الجديد 
        ///
        /// **Figma Link:**
        /// * [Figma Prototype mobile](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=1263-18032&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
        /// * [Figma Prototype web](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=294%3A741&amp;node-id=475-7853&amp;node-type=frame&amp;viewport=-285%2C-1106%2C0.21&amp;t=0sKGniGTkxh2porv-1&amp;scaling=min-zoom&amp;content-scaling=fixed&amp;starting-point-node-id=298%3A72&amp;hide-ui=1)
        ///
        /// Sample request:
        /// 
        ///      {
        ///          "DeviceId": "TEST",
        ///      }
        ///      
        /// </remarks>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request or validation error</response>
        /// <response code="500">Internal server error</response>
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete("Logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutDto input)
        {
            var result = await _accountService.Logout(input, userId);
            return StatusCode(result.StatusCode, result);
        }



        /// <summary>
        /// RemoveAccount.
        ///    مسح الاكونت.
        /// </summary>
        /// <remarks>
        /// # يتم استخدام هذا الطلب  لمسح اكونت المستخدم.
        ///
        /// 
        /// **Figma Link:**
        /// * [Figma Link](https://www.figma.com/proto/BA1vLTyVKHblKF4uYKKeHY/%D8%AA%D8%B7%D8%A8%D9%8A%D9%82-%D9%88%D9%85%D9%88%D9%82%D8%B9-Bita-gift?page-id=0%3A1&amp;node-id=143-1029&amp;viewport=554%2C213%2C0.22&amp;t=NmGFsHtNtVhg79fw-1&amp;scaling=scale-down&amp;content-scaling=fixed&amp;starting-point-node-id=27%3A2)
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
        [ProducesResponseType(typeof(Result<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [HttpDelete("RemoveAccount")]
        public async Task<IActionResult> RemoveAccount()
        {
            var result = await _accountService.RemoveAccount(userId);
            return StatusCode(result.StatusCode, result);
        }


    }
}
