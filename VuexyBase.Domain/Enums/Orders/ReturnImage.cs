using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Enums.Orders
{
    public class ReturnImage
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public int ReturnId { get; set; }

        // Navigation Properties :

        [ForeignKey(nameof(ReturnId))]
        public virtual ReturnStatus Return { get; set; }
    }
}
