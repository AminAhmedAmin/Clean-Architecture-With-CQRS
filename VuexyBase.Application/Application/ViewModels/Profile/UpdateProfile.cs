using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Profile
{
    public class UpdateProfileViewModel
    {
        public IFormFile newImage { get; set; }

        public string oldImage { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل الاسم")]
        public string name { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل رقم الهاتف")]
        public string phone { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل البريد الالكتروني")]
        public string email { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل اسم المشروع")]
        public string organizationName { get; set; }

        [Required(ErrorMessage = "من فضلك ادخل العنوان")]
        public string address { get; set; }
    }

}
