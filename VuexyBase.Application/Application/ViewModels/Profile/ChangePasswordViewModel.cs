using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Profile
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور الحالية")]
        public string currentPassword { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل كلمة المرور الجديدة")]
        public string newPassword { get; set; }

        [Required(ErrorMessage = "من فضلك اعد كتابة كلمة المرور الجديدة")]
        [Compare("newPassword", ErrorMessage = "كلمة المرور غير متطابقة")]
        public string confirmPassword { get; set; }
    }
}
