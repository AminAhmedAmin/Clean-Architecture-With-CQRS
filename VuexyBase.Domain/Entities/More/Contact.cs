using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.More
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool IsRead { get; set; }= false;
    }
}
