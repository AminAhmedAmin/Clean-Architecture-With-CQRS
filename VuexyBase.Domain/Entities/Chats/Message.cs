using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuexyBase.Domain.Entities.Chats
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        public int RoomId { get; set; }

        public string Text { get; set; }

        public string? File { get; set; }

        public bool IsDeletedSender { get; set; }

        public bool IsDeletedReceiver { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;



        #region Navigation Properties

        [ForeignKey(nameof(RoomId))]
        public virtual Room Room { get; set; }

        #endregion
    }
}
