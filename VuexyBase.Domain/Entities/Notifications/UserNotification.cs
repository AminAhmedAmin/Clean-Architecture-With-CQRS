using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Notifications;

namespace VuexyBase.Domain.Entities.Notifications
{
    public class UserNotification
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string MessageAr { get; set; }
        public string MessageEn { get; set; }


        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public NotificationType Type { get; set; }

        public bool IsSeen { get; set; }

        public int? ItemId { get; set; }



        #region Navigation Properties

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }

        #endregion
    }
}
