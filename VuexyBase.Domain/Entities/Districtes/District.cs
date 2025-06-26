using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Cities;

namespace VuexyBase.Domain.Entities.Districtes
{
    public class District
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CityId { get; set; }
        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
    }
}
