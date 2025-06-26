using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.DTOs.More.AppInfo
{
    public class ContactWithUsDto
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Subject { get; set; }

        
        [Required]
        public string Message { get; set; }
       
    }
}
