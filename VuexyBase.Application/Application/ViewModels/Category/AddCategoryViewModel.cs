using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Category
{
    public class AddCategoryViewModel
    {
        [Required(ErrorMessage ="name ar is required")]
        public string NameAr { get; set; }

        [Required(ErrorMessage = "name en is required")]
        public string NameEn { get; set; }
        public bool IsActive { get; set; }

    }
}
