using System.ComponentModel.DataAnnotations.Schema;
using VuexyBase.Domain.Entities.Countries;
using VuexyBase.Domain.Entities.Districtes;

namespace VuexyBase.Domain.Entities.Cities
{
    public class City
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public virtual Country country { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<District> Districts { get; set; }
    }
}
