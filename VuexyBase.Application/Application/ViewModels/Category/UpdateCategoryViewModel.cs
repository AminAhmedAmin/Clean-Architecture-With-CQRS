using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Category
{
    public class UpdateCategoryViewModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Image { get; set; } = "ssssssssssss";

        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; } = DateTime.UtcNow;
    }
}
