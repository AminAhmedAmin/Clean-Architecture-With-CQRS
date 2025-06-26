using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.More
{
    public class Slider
    {
        [Key]
        public int Id { get; set; }

        public string Image { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime ExpirationDate { get; set; }

        public bool IsActive { get; set; }
    }
}
