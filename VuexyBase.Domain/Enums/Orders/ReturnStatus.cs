using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Domain.Enums.Orders
{    /// <summary>
     /// حالة المرتجع
     /// </summary>
    public enum ReturnStatus : byte
    {
        /// <summary>
        ///   قيد المراجعة  
        /// </summary>
        UnderReview = 1,

        /// <summary>
        ///   جاري الاسترجاع  
        /// </summary>
        Returning = 2,

        /// <summary>
        ///   تم الارجاع  
        /// </summary>
        Returned = 3,

        /// <summary>
        ///   تم رفض الارجاع  
        /// </summary>
        ReturnRefused = 4,
    }
}
