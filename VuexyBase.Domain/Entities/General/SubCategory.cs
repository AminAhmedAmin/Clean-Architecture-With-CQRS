using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Entities.Orders;
using VuexyBase.Domain.Enums.Orders;

namespace VuexyBase.Domain.Entities.General
{
    public class SubCategory : BaseEntity
    {
        public SubCategory()
        {
            Orders = new HashSet<Order>();
        }

        public int CategoryId { get; set; }


        // Navigation Properties :

        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [InverseProperty(nameof(Order.SubCategory))]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
