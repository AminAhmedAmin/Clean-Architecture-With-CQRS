using System.ComponentModel.DataAnnotations;

namespace VuexyBase.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        //This property will be arabic if the entity has language
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.UtcNow;

        public DateTime? UpdateDate { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }
}
