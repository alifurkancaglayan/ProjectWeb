using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public HomeController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var bookCount = _bookService.GetAllBookAsync(false).Count();
            var categoryCount = _categoryService.GetAllCategoryAsync(false).Count();
            ViewBag.BookCount = bookCount;
            ViewBag.CategoryCount = categoryCount;
            return View();
        }
    }
}
