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
using VuexyBase.Domain.Enums.Orders;

namespace VuexyBase.Domain.Entities.Orders
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string? BuyerId { get; set; }

        public string SellerId { get; set; }

        public double Lat { get; set; }

        public double Lng { get; set; }

        public string? Address { get; set; }

        public string PostalCode { get; set; }
        public string Region { get; set; }
        public string Street { get; set; }
        public string AdditionalCode { get; set; }
        public string LocationDescription { get; set; }
        public decimal Prce { get; set; }
        public double ApplicationCommission { get; set; }
        public double AddedValue { get; set; }
        public double ShippingCost { get; set; } = 0;
        public double DiscountValue { get; set; } = 0;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime? AcceptedDate { get; set; }
        public bool IsSettled { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public int SubcategoryId { get; set; }
        public int? CancellationReasonId { get; set; }
        public int CityId { get; set; }



        // Navigation Properties :  

        [ForeignKey(nameof(BuyerId))]
        public virtual ApplicationDbUser? Buyer { get; set; }

        [ForeignKey(nameof(SellerId))]
        public virtual ApplicationDbUser? Seller { get; set; }

        [ForeignKey(nameof(SubcategoryId))]
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey(nameof(CancellationReasonId))]
        public virtual CancellationReason? CancellationReason { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

    }
}
