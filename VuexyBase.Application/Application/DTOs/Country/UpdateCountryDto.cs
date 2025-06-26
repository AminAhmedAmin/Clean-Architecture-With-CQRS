using Microsoft.AspNetCore.Http;

namespace VuexyBase.Application.Application.DTOs.Country
{
    public class UpdateCountryDto
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Code { get; set; }
        public IFormFile? Image { get; set; }
    }
}
