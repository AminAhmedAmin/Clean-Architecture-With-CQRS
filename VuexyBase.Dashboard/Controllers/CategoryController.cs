using Microsoft.AspNetCore.Mvc;
using VuexyBase.Application.Application.Contracts.Application.Dashboard.Category;
using VuexyBase.Application.Application.ViewModels.Category;
using VuexyBase.Domain.Entities.General;

namespace VuexyBase.Dashboard.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            ListCategoryViewModel categories = await _categoryService.GetAllCategories();
            return View(categories);
        }

        [HttpPost]

        public async Task<IActionResult> Create(AddCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return PartialView("_PartialAddCategory", model);

            }
            await _categoryService.CreateCategory(model);
            ListCategoryViewModel categories = await _categoryService.GetAllCategories();

                //Response.Headers["HX-Trigger"] = "toggleOffcanvas";
            Response.Headers["HX-Trigger"] = "categoryUpdated";
            return  PartialView("_CategoryTablePartial", categories);
         
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCategoryViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return PartialView("_PartialEditCategory", model);
            }

            var res = await _categoryService.EditCategory(model);
            ListCategoryViewModel categories = await _categoryService.GetAllCategories();
                Response.Headers["HX-Trigger"] = "toggleOffcanvas";
                return PartialView("_CategoryTablePartial", categories);
            
           
        }


        public async Task<IActionResult> GetTablePartial()
        {
            var categories = await _categoryService.GetAllCategories();
            return PartialView("_CategoryTablePartial", categories);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.DeleteCategory(id);
            ListCategoryViewModel categories = await _categoryService.GetAllCategories();
            return PartialView("_CategoryTablePartial", categories);
           
        }

        public async Task<IActionResult> Status(int id)
        {
            var res = await _categoryService.ChangeStatus(id);
            ListCategoryViewModel categories = await _categoryService.GetAllCategories();
            if (res)
            {
                return PartialView("_CategoryTablePartial", categories);

            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}
