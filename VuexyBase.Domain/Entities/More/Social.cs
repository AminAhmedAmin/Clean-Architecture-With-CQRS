using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities.More
{
    public class Social
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public bool IsActive { get; set; }
    }
}
