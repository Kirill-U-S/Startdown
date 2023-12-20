using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Startdown.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MainPageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MainPageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MainPageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainPageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainPageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MainPageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MainPageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MainPageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
