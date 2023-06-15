using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var books = _bookService.GetBookListWithCategory();
            return View(books);
        }
    }
}
