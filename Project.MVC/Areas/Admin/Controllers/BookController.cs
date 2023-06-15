using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;

        public BookController(IBookService bookService, ICategoryService categoryService)
        {
            _bookService = bookService;
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _bookService.GetBookListWithCategory();
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categoryValues = _categoryService.GetAllCategoryAsync(false);
            ViewBag.cv = categoryValues;

            return View();
        }

        [HttpPost]
        public IActionResult Add(Book model, IFormFile formFile)
        {

            if (formFile != null && formFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    formFile.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    model.BookImage = imageBytes;
                }
                _bookService.CreateOneBook(model);
                return RedirectToAction("Index");
            }


            return View();
        }

        public IActionResult Delete(int bookId)
        {
            var data = _bookService.GetBookByIdAsync(bookId, false);
            _bookService.DeleteOneBook(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int bookId)
        {
            var data = _bookService.GetBookByIdAsync(bookId, false);
            List<Category> categoryValues = _categoryService.GetAllCategoryAsync(false);
            ViewBag.cd = categoryValues;
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Book model, IFormFile formFile)
        {
            if (formFile != null && formFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    formFile.CopyTo(memoryStream);
                    byte[] imageBytes = memoryStream.ToArray();
                    model.BookImage = imageBytes;
                }
                _bookService.UpdateOneBook(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}

