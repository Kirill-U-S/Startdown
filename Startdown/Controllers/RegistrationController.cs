using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace Startdown.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegPage(string Login, string Password)
        {
            string connstr = "Data Source=DESKTOP-UIR8C5V;Initial Catalog=StartDown_DB;Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                conn.Open();
                string query = "select COUNT(*) from [dbo].[User]" +
                    $"where [dbo].[User].[Login] = '{Login}'";

                SqlCommand command = new SqlCommand(query, conn);
                int count = (int)command.ExecuteScalar();

                if(count >= 0)
                {
                    if (count > 0)
                    {
                        TempData["Message"] = "Данный логин занят";
                        conn.Close();
                        return RedirectToAction("Index", "Registration");
                    }
                    else
                    {
                        string queryreg = $"INSERT INTO [dbo].[User] (Login, Password, ID_Order) VALUES ('{Login}', '{Password}', 1)";
                        SqlCommand commandreg = new SqlCommand(queryreg, conn);
                        commandreg.ExecuteNonQuery();
                        conn.Close();
                        return RedirectToAction("Index", "MainPage");
                    }
                }
                else
                {
                    conn.Close();
                    TempData["Message"] = "Произошел сбой в базе данных. Напишите в службу поддержки";
                    return RedirectToAction("Index", "Registration");
                }
            }
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
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

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
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

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
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
