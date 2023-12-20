using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Startdown.Controllers
{
    public class BuyPageController : Controller
    {
        // GET: BuyPageController
        public ActionResult Index()
        {
            return View();
        }

        // GET: BuyPageController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BuyPageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuyPageController/Create
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

        // GET: BuyPageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BuyPageController/Edit/5
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

        // GET: BuyPageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BuyPageController/Delete/5
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
