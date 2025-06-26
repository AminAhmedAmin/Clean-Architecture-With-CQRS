using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Identities;
using VuexyBase.Domain.Enums.Chats;

namespace VuexyBase.Domain.Entities.Chats
{
    public class Room
    {
        public Room()
        {
            Messages = new HashSet<Message>();
        }
        [Key]
        public int Id { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }


        public ChatType ChatType { get; set; }

        public int? ItemId { get; set; } //It depends on the chat type

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool IsDeleted { get; set; }


        #region Navigation Properties
        public virtual ICollection<Message> Messages { get; set; }

        [ForeignKey(nameof(SenderId))]
        public virtual ApplicationDbUser Sender { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public virtual ApplicationDbUser Receiver { get; set; }
        #endregion
    }
}
