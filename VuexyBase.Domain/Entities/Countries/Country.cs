using VuexyBase.Domain.Entities.Cities;

namespace VuexyBase.Domain.Entities.Countries
{
    public class Country
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
