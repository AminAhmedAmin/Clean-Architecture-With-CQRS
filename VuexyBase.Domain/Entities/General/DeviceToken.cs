using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Devices;

namespace VuexyBase.Domain.Entities.General
{
    public class DeviceToken
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Token { get; set; }

        public DeviceType DeviceType { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        #region Navigation Properties

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationDbUser User { get; set; }

        #endregion
    }
}
