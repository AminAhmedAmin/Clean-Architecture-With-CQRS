using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Auth
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "من فضلك ادخل البريد الالكتروني ")]
        public string email { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور ")]
        public string password { get; set; }
    }
}
