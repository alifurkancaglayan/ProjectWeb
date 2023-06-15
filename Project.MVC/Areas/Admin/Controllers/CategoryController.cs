using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _categoryService.GetAllCategoryAsync(false);
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Category model)
        {
            if (ModelState.IsValid)
            {
                _categoryService.CreateOneCategory(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int categoryId)
        {
            var data = _categoryService.GetCategoryByIdAsync(categoryId, false);
            _categoryService.DeleteOneCategory(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int categoryId)
        {
            var data = _categoryService.GetCategoryByIdAsync(categoryId, false);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Category model)
        {
            if (ModelState.IsValid)
            {

                _categoryService.UpdateOneCategory(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

