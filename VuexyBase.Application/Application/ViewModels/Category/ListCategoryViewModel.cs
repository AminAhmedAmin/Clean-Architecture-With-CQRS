using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Application.Application.ViewModels.Category
{
    public class ListCategoryViewModel
    {
           
        public int CategoryNumber { get; set; }
        public int ActiveNumber { get; set; }
        public int DisabledNumber { get; set; }
        public List<CategorisList> Categories { get; set; } = new List<CategorisList>();

    }

    public class CategorisList
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
