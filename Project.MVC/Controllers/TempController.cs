using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Project.MVC.Controllers
{
    public class TempController : Controller
    {
        private readonly ITempService _tempService;

        public TempController(ITempService tempService)
        {
            _tempService = tempService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _tempService.GetAllTempAsync(false);
            return View(data);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Add(Temp model)
        {
            if (ModelState.IsValid)
            {
                _tempService.CreateOneTemp(model);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int tempId)
        {
            var data = _tempService.GetTempByIdAsync(tempId, false);
            _tempService.DeleteOneTemp(data);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int tempId)
        {
            var data = _tempService.GetTempByIdAsync(tempId, false);
            return View(data);
        }

        [HttpPost]
        public IActionResult Update(Temp model)
        {
            if (ModelState.IsValid)
            {

                _tempService.UpdateOneTemp(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
