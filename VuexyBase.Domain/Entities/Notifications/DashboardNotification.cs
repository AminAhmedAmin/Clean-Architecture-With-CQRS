using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.Notifications
{
    public class DashboardNotification
    {
        [Key]
        public int Id { get; set; }

        public string Message { get; set; }

        public int UsersCount { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
    }
}
