using System.ComponentModel.DataAnnotations;
using VuexyBase.Domain.Enums.Payments;

namespace VuexyBase.Domain.Entities.Payments
{
    public class PaymentTransaction
    {
        [Key]
        public string PaymentTransactionId { get; set; } = Guid.NewGuid().ToString();

        public string UserId { get; set; }

        public int? ItemId { get; set; } //It depends On payment target

        public double InvoiceAmount { get; set; } // Raw before service charge

        public int? InvoiceId { get; set; }

        public string? PaymentId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime LastModificationDate { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public PaymentTarget PaymentTarget { get; set; }
    }
}
