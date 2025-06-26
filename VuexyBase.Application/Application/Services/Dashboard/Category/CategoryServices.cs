using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Category;
using VuexyBase.Application.Application.ViewModels.Category;
using VuexyBase.Application.Persistence;
using VuexyBase.Domain.Entities.General;

namespace VuexyBase.Application.Application.Services.Dashboard.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;
        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ListCategoryViewModel> GetAllCategories()
        {
            ListCategoryViewModel listCategoryViewModel = new ListCategoryViewModel();
            var categories = await _context.Categories.ToListAsync();
            listCategoryViewModel.ActiveNumber = categories.Count(c => (c.IsActive == true && c.IsDeleted == false));
            listCategoryViewModel.DisabledNumber = categories.Count(c => (c.IsActive == false && c.IsDeleted == false));
            listCategoryViewModel.CategoryNumber = categories.Count(c => c.IsDeleted == false);
            listCategoryViewModel.Categories = categories.Where(c => c.IsDeleted == false).Select(c => new CategorisList
            {
                Id = c.Id,
                NameAr = c.NameAr,
                NameEn = c.NameEn,
                Image = "aaa",
                IsActive = c.IsActive,
                CreationDate = c.CreationDate,
                UpdateDate = c.UpdateDate
            }).ToList();

            return listCategoryViewModel;

        }

        public async Task<bool> EditCategory(UpdateCategoryViewModel categoryVM)
        {
            var category = await _context.Categories.FindAsync(categoryVM.Id);
            category.NameAr = categoryVM.NameAr;
            category.NameEn = categoryVM.NameEn;
            category.UpdateDate = DateTime.UtcNow;
            category.IsActive = categoryVM.IsActive;
            category.Image = "aaa";
            try
            {
                 _context.Categories.Update(category);
                await _context.SaveChangesAsync();
                return true;

            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> CreateCategory(AddCategoryViewModel category)
        {
            var categoryEntity = new VuexyBase.Domain.Entities.General.Category
            {
                NameAr = category.NameAr,
                NameEn = category.NameEn,
                CreationDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                IsActive = category.IsActive,
                IsDeleted = false,
                Image = "aaa"
            };
            try
            {
                _context.Categories.Add(categoryEntity);
                await _context.SaveChangesAsync();
                return true;
            }catch
            {
                return false;
            }
       
        }

        [HttpDelete]
        public async Task<bool> DeleteCategory(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            category.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost]
        public async Task<bool> ChangeStatus(int id)
        {
            VuexyBase.Domain.Entities.General.Category categoryStat = await _context.Categories.FindAsync(id);
            categoryStat.IsActive = !categoryStat.IsActive;
            try
            {
                _context.Categories.Update(categoryStat);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false; 
            }
        }
    }
}
