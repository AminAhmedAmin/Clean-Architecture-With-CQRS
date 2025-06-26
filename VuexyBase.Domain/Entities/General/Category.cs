using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Entities.General
{
    public class Category : BaseEntity
    {
        public Category()
        {
            SubCategories = new HashSet<SubCategory>();
        }

        public string Image { get; set; }

        // Navigation Properties :

        [InverseProperty(nameof(SubCategory.Category))]
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
