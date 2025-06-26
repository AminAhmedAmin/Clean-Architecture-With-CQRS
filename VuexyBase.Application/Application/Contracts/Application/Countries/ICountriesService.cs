using VuexyBase.Application.Application.DTOs.Country;
using VuexyBase.Application.Common.Results;

namespace VuexyBase.Application.Application.Contracts.Application.Countries
{
    public interface ICountriesService
    {
        public Task<bool> IsActive(int countryId);
        public Task<bool> Delete(int countryId);
        public Task<bool> AddCountry(AddCountryDto dto);
        public Task<bool> UpdateCountry(UpdateCountryDto dto);
        public Task<CountryDto> GetCountry(int countryId);
        Task<Paging<CountryDto>> FilterCountries(CountryFilterRequest? filter);
        Task<bool> DeleteMultiple(List<int> Ids);
    }
}
