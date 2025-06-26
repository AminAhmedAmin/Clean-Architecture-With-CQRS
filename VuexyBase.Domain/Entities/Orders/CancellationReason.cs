using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VuexyBase.Domain.Entities.Orders
{
    public class CancellationReason
    {
        [Key]
        public int Id { get; set; }

        public string TextAr { get; set; }

        public string TextEn { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; }
    }
}
