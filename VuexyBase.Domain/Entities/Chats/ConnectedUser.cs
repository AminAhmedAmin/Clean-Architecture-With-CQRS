using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.Chats
{
    public class ConnectedUser
    {
        [Key]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ConnectionId { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
