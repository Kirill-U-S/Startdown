using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class ChangeLoginController : Controller
    {
        // GET: ChangeLoginController
        public ActionResult Index()
        {
            return View();
        }

        public IActionResult B_ChangeLogin(string Login)
        {
            if (HttpContext.Session.GetString("id") == null)
            {
                TempData["Message"] = $"Авторизуйтесь или зарегистрируйтесь";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                //считали id пользователя
                int id = 0;
                id = int.Parse(HttpContext.Session.GetString("id"));
                string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connstr))
                {
                    conn.Open();
                    string query = "UPDATE[dbo].[User]" +
                        $"SET[dbo].[User].[Login] = '{Login}'" +
                        $"WHERE[dbo].[User].[id] = '{id}'";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                return RedirectToAction("Index", "MainPage");
            }
        }

        // GET: ChangeLoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChangeLoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChangeLoginController/Create
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

        // GET: ChangeLoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChangeLoginController/Edit/5
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

        // GET: ChangeLoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChangeLoginController/Delete/5
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
