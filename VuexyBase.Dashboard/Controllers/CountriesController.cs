using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Contracts.Application.Countries;
using VuexyBase.Application.Application.DTOs.Country;

namespace VuexyBase.Dashboard.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;
        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddCountryDto dto)
        {
            var result = await _countriesService.AddCountry(dto);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return View(dto);
            }
        }
        [HttpGet("Countries/Update/{countryId}")]
        public async Task<IActionResult> Update(int countryId)
        {
            var country = await _countriesService.GetCountry(countryId);
            return View(country);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryDto dto)
        {
            var result = await _countriesService.UpdateCountry(dto);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return View(dto);
            }
        }
        [HttpPost("Countries/Delete/{countryId}")]
        public async Task<IActionResult> Delete(int countryId)
        {
            var result = await _countriesService.Delete(countryId);
            if (result)
            {
                return Json(new { success = true });
            }
            else
            {
                return Json(new { success = false });
            }
        }
        [HttpPost]
        public async Task<IActionResult> IsActive(int countryId)
        {
            var result = await _countriesService.IsActive(countryId);
            return Json(new { success = result });
        }
        public async Task<IActionResult> GetCountries(CountryFilterRequest? filter)
        {
            var result = await _countriesService.FilterCountries(filter);
            return Json(result);
        }

        public async Task<IActionResult> DeleteMultiple(List<int> Ids)
        {
            var result = await _countriesService.DeleteMultiple(Ids);
            return Json(new { success = result });
        }
    }
}
