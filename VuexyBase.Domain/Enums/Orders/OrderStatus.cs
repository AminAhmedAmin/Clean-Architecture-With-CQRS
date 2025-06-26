using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Domain.Entities.Cities;
using VuexyBase.Domain.Entities.General;
using VuexyBase.Domain.Entities.Identities;

namespace VuexyBase.Domain.Enums.Orders
{


        /// <summary>
        /// حالة الطلب
        /// </summary>
        public enum OrderStatus : byte
        {
            /// <summary>
            ///   قيد الانتظار  
            /// </summary>
            Pending = 1,

            /// <summary>
            ///   قيد الدفع  
            /// </summary>
            PaymentPending = 2,

            /// <summary>
            ///   جاري التسليم  
            /// </summary>
            DeliveryInProgress = 3,

            /// <summary>
            ///  تم التسليم لشركة الشحن  
            /// </summary>
            Delivered = 4,

            /// <summary>
            ///   مكتمل  
            /// </summary>
            Complete = 5,

            /// <summary>
            ///   ملغي  
            /// </summary>
            Cancelled = 6,

            /// <summary>
            ///   ارتجاع  
            /// </summary>
            Return = 7,
        }
    }

