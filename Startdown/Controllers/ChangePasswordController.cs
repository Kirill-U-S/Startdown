using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class ChangePasswordController : Controller
    {
        // GET: ChangePasswordController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult B_ChangePass(string Passwordold, string Passwordnew)
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
                        $"SET[dbo].[User].[Password] = '{Passwordnew}'" +
                        $"WHERE[dbo].[User].[id] = '{id}' and [dbo].[User].[Password] = '{Passwordold}'";
                    SqlCommand command = new SqlCommand(query, conn);
                    command.ExecuteNonQuery();
                    conn.Close();
                }
                return RedirectToAction("Index", "MainPage");
            }
        }

        // GET: ChangePasswordController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChangePasswordController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChangePasswordController/Create
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

        // GET: ChangePasswordController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChangePasswordController/Edit/5
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

        // GET: ChangePasswordController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChangePasswordController/Delete/5
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
