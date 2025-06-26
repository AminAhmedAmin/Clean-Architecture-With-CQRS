namespace VuexyBase.Application.Application.DTOs.Country
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string Code { get; set; }
        public string Image { get; set; }
        public bool isDeleted { get; set; }
        public bool isActive { get; set; }
        public bool IsAvaliableToDelete { get; set; }
    }
}
