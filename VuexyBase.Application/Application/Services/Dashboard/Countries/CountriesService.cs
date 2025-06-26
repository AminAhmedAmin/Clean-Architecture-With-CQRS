using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using VuexyBase.Application.Application.Common.Helpers;
using VuexyBase.Application.Application.Contracts.Application.Countries;
using VuexyBase.Application.Application.DTOs.Country;
using VuexyBase.Application.Common.Results;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Entities.Countries;
using VuexyBase.Domain.Enums.Helper;
using VuexyBase.Domain.Helpers;

namespace VuexyBase.Application.Application.Services.Countries
{

    public class CountriesService : ICountriesService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment HostingEnvironment;
        public CountriesService(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            HostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> AddCountry(AddCountryDto dto)
        {
            var country = new Country
            {
                NameAr = dto.NameAr,
                NameEn = dto.NameEn,
                Code = dto.Code,
                Image = UploadHelper.Upload(dto.Image, (int)FileName.Country, HostingEnvironment),
                isActive = true,
                isDeleted = false
            };

            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int countryId)
        {
            var country = _context.Countries.Find(countryId);
            //logic to not delete
            if (country == null)
            {
                return false;
            }
            country.isDeleted = true;
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Paging<CountryDto>> FilterCountries(CountryFilterRequest? filter)
        {
            var countries = _context.Countries.AsQueryable();






            var totalRecords = await countries.CountAsync();
            var filteredRecords = totalRecords; // After filtering

            // Start with the base query
            IQueryable<Country> orderedCountries = countries;

            if (filter.Order?.Any() == true)
            {
                var order = filter.Order[0];
                var column = filter.Columns[order.Column];
                orderedCountries = countries.OrderByExtension(column.Data, order.Dir);
            }

            var data = orderedCountries
                .SearchInAllStringProperties(filter.Search?.Value)
                .FilterWithDate(filter.StartDate, filter.EndDate)
                .Skip(filter.Start)
                .Take(filter.Length == 0 ? 10 : filter.Length)
                .ToList()
                .Select(x => new CountryDto
                {
                    Id = x.Id,
                    NameAr = x.NameAr,
                    NameEn = x.NameEn,
                    Code = x.Code,
                    Image = x.Image,
                    isActive = x.isActive,
                    IsAvaliableToDelete = IsAvaliableToDelete(x.Id)
                })
                .ToList();

            return new Paging<CountryDto>
            {
                Result = data,
                Pagination = new PagingDetails
                {
                    CurrentPage = (filter.Start / filter.Length) + 1,
                    PageSize = filter.Length,
                    recordsTotal = totalRecords,
                    recordsFiltered = filteredRecords,
                    Draw = filter.Draw
                }
            };
        }

        public async Task<CountryDto> GetCountry(int countryId)
        {
            var country = await _context.Countries.FindAsync(countryId);
            var countryDto = new CountryDto
            {
                Id = country.Id,
                NameAr = country.NameAr,
                NameEn = country.NameEn,
                Code = country.Code,
                Image = country.Image,
                isActive = country.isActive
            };
            return countryDto;
        }

        public async Task<bool> IsActive(int countryId)
        {
            var country = _context.Countries.Find(countryId);
            country.isActive = !country.isActive;
            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return country.isActive;
        }

        public async Task<bool> UpdateCountry(UpdateCountryDto dto)
        {
            var country = _context.Countries.Find(dto.Id);
            country.NameAr = dto.NameAr;
            country.NameEn = dto.NameEn;
            country.Code = dto.Code;
            if (dto.Image != null)
            {
                country.Image = UploadHelper.Upload(dto.Image, (int)FileName.Country, HostingEnvironment);
            }

            _context.Countries.Update(country);
            await _context.SaveChangesAsync();
            return true;
        }
        public bool IsAvaliableToDelete(int countryId)
        {
            var country = _context.Countries.Find(countryId);

            //logicc to not delete
            if (country.Id == 5)
            {
                return false;
            }

            return true;
        }

        public Task<bool> DeleteMultiple(List<int> Ids)
        {
            _context.Countries.RemoveRange(_context.Countries.Where(x => Ids.Contains(x.Id)));
            return _context.SaveChanges() > 0 ? Task.FromResult(true) : Task.FromResult(false);
        }
    }
}
