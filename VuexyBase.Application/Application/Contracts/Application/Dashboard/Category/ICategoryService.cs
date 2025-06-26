using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VuexyBase.Application.Application.ViewModels.Category;

namespace VuexyBase.Application.Application.Contracts.Application.Dashboard.Category
{
    public interface ICategoryService
    {
        Task<ListCategoryViewModel> GetAllCategories();

        Task<bool> EditCategory(UpdateCategoryViewModel categoryVM);
        Task<bool> CreateCategory(AddCategoryViewModel category);
        Task<bool> DeleteCategory(int id);

        Task<bool> ChangeStatus(int id);
    }
}
